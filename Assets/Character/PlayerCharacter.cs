using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace Amity
{
	public class PlayerCharacter : MonoBehaviour
    {
		[Header("Input")]
		public PlayerInput playerInput;

		[Header("Physics")]
		public OverlapChecker2D footHitbox;
		public BoxCollider2D boxCollider;
		public new Rigidbody2D rigidbody;

		[Header("Jumping")]
		public float jumpForce;

		[Header("Running")]
		public float runSpeed;

		[Header("Twin")]
		public bool hasTwin;

		public CharacterState currentState;

		public event Action<int> onDirectionChanged;

		private int currentDirection;

		private void Awake() {
			currentState = new GroundedState(this);
		}

		private void OnEnable() {
			currentState.OnEnter();
		}

		private void OnDisable() {
			currentState.OnExit();
		}

		private void Update() {
			SwitchTo(currentState.OnLogicUpdate());
		}

		private void FixedUpdate() {
			SwitchTo(currentState.OnPhysicsUpdate());
		}

		private void OnJump() {
			SwitchTo(currentState.OnJump());
		}

		private void OnRun(InputValue inputValue) {
			int newDirection = inputValue.Get<int>();
			if (newDirection == currentDirection)
				return;
			onDirectionChanged?.Invoke(newDirection);
			SwitchTo(currentState.OnRun(newDirection));
		}

		private void SwitchTo(CharacterState newState) {
			if (newState == null)
				return;

			currentState.OnExit();
			currentState = newState;
			currentState.OnEnter();
		}
	}
}

using UnityEngine.InputSystem;
using UnityEngine;

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

		public CharacterState currentState;

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

		private void OnJump(InputValue inputValue) {
			SwitchTo(currentState.OnJump(inputValue));
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

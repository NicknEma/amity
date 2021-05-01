using UnityEngine.InputSystem;
using UnityEngine;

namespace Amity
{
    public class PlayerCharacter : MonoBehaviour
    {
		[Header("Input")]
		public PlayerInput playerInput;

		[Header("Physics")]
		public BoxCollider2D boxCollider;
		public Rigidbody2D rigidbody;

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
			SwitchTo(currentState.OnUpdate());
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

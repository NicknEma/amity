using UnityEngine.InputSystem;
using UnityEngine;

namespace Amity
{
	public class PlayerCharacter : MonoBehaviour
    {
		#region FIELDS

		[Header("General")]
		public Animator animator;
		public AudioEmitter audioEmitter;
		
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

		#endregion

		#region PRIVATE_METHODS

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

		private void OnPound() {
			SwitchTo(currentState.OnPound());
		}

		private void OnJump() {
			SwitchTo(currentState.OnJump());
		}

		private void OnRun(InputValue inputValue) {
			int direction = (int) inputValue.Get<float>();
			SwitchTo(currentState.OnRun(direction));
		}

		private void SwitchTo(CharacterState newState) {
			if (newState == null)
				return;

			currentState.OnExit();
			currentState = newState;
			currentState.OnEnter();
		}

		#endregion
	}
}

using UnityEngine.InputSystem;
using TypeReferences;
using UnityEngine;

namespace Amity
{
	public class PlayerCharacter : MonoBehaviour
	{
		#region PROPERTIES

		public CharacterState CurrentState => currentState;

		public int GravityScale {
			get {
				return (int) Mathf.Clamp(rigidbody.gravityScale, -1, 1);
			}
		}

		#endregion

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

		[Header("Movement")]
		public float poundSpeed;
		public float jumpForce;
		public float runSpeed;

		[Header("Twin")]
		public bool hasTwin;
		public GameObject twin;

		[Header("State Machine")]
		[ClassExtends(typeof(CharacterState))]
		public ClassTypeReference initialState;

		private CharacterState currentState;

		#endregion

		#region PUBLIC_METHODS

		public void OnTwinHidden() {
			transform.position = twin.transform.position;
			SwitchTo(new JumpingState(this));
		}

		#endregion

		#region PRIVATE_METHODS

		private void Awake() {
			currentState = (CharacterState) System.Activator.CreateInstance(initialState, new PlayerCharacter[] { this });
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

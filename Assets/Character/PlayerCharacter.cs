using UnityEngine.InputSystem;
using UnityEngine.Events;
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
		public new Collider2D collider;
		public new Rigidbody2D rigidbody;
		public PhysicsMaterial2D lowFriction;
		public PhysicsMaterial2D highFriction;

		[Header("Movement")]
		public float poundSpeed;
		public float jumpForce;
		public float runSpeed;

		[Header("Twin")]
		public bool requiresSwitcher;
		public GameObject twin;

		[Header("State Machine")]
		[ClassExtends(typeof(CharacterState))]
		public ClassTypeReference initialState;

		[Header("Unity Events")]
		public UnityEvent onGroundPound;

		private CharacterState currentState;

		public int CurrentHorizontalInput { get; private set; }

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
			SwitchTo(currentState.OnPound(CurrentHorizontalInput));
		}

		private void OnJump() {
			SwitchTo(currentState.OnJump());
		}

		private void OnRun(InputValue inputValue) {
			CurrentHorizontalInput = (int) inputValue.Get<float>();
			SwitchTo(currentState.OnRun());
		}

		private void SwitchTo(CharacterState newState) {
			if (newState == null)
				return;

			currentState.OnExit();
			currentState = newState;
			currentState.OnEnter();
		}

		#endregion

		#region DEBUGGING_STUFF

		[ContextMenu("Print Current State")]
		private void PrintCurrentState() {
			Debug.Log(currentState.ToString());
		}

		#endregion
	}
}

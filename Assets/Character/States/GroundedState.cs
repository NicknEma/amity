using UnityEngine;

namespace Amity
{
    public class GroundedState : CharacterState
    {		
		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.audioEmitter.PlaySelected("Landings");
			character.animator.SetInteger("Vertical Speed", 0);
		}

		// TODO: Lerp position instead of assigning it directly (both here and in OnPhysicsUpdate)
		public override void OnExit() {
			character.animator.transform.localPosition = Vector2.zero;
			SetMaterial(1);
		}

		public override CharacterState OnPhysicsUpdate() {
			Vector2 normal = GetGroundNormal();
			Vector2 tangent = -Vector2.Perpendicular(normal);

			Vector2 speed = new Vector2(
				character.runSpeed * tangent.x * character.CurrentHorizontalInput,
				character.runSpeed * tangent.y * character.CurrentHorizontalInput);

			if (Input.GetKeyDown(KeyCode.I))
				Debug.Log($"{character.runSpeed * tangent.x}, {character.runSpeed * tangent.y}");

			character.rigidbody.velocity = speed;

			SetMaterial(character.CurrentHorizontalInput);

			UpdateGraphics(speed, normal);

			if (!character.footHitbox.isHitting)
				return new FallingState(character);
			return null;
		}

		private Vector2 GetGroundNormal() {
			float distance = 0.5f;
			Vector2 origin = (Vector2) character.transform.position - new Vector2(0.5f, 0.0f);
			RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, 1 << LayerMask.NameToLayer("Ground"));

			Vector2 normal = hit.normal == Vector2.zero ? Vector2.up : hit.normal.normalized;

#if UNITY_EDITOR
			Debug.DrawRay(origin, Vector2.down * distance, Color.red);
			Debug.DrawRay(origin, normal, Color.yellow);
#endif
			return normal;
		}

		private void SetMaterial(int currentHorizontalInput) {
			if (currentHorizontalInput == 0)
				character.rigidbody.sharedMaterial = character.highFriction;
			else
				character.rigidbody.sharedMaterial = character.lowFriction;
		}

		private void UpdateGraphics(Vector2 speed, Vector2 normal) {
			character.animator.SetInteger("Horizontal Speed", (int) speed.x);

			if (normal != Vector2.up)
				character.animator.transform.localPosition = new Vector2(0.0f, -0.3f);
			else
				character.animator.transform.localPosition = Vector2.zero;
		}

		public override CharacterState OnJump() {
			return new JumpingState(character);
		}
	}
}

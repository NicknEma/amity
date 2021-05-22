using UnityEngine;

namespace Amity
{
    public class HiddenState : CharacterState
    {
        public HiddenState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.boxCollider.enabled = false;
			character.rigidbody.isKinematic = true;

			// character.animator.SetBool("Is Visible", false);
		}

		public override void OnExit() {
			character.boxCollider.enabled = true;
			character.rigidbody.isKinematic = false;

			// character.animator.SetBool("Is Visible", true);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (!character.hasTwin)
				return null;

			character.transform.position = new Vector2(character.twin.transform.position.x, character.transform.position.y);
			return null;
		}
	}
}

/*
			float x = character.twin.transform.position.x;
			Debug.Log($"Origin: {character.transform.position}, direction: {((character.rigidbody.gravityScale < 0) ? Vector2.up : Vector2.down)}");
			var hit = Physics2D.Raycast(character.transform.position, character.rigidbody.gravityScale < 0 ? Vector2.up : Vector2.down, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground"));
			Debug.Log(hit.collider);
			Debug.Log($"{x}, {hit.point.y}");
			character.transform.position = new Vector2(x, hit.point.y);
			*/

using UnityEngine;

namespace Amity
{
    public class HiddenState : CharacterState
    {
        public HiddenState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.boxCollider.enabled = false;
			character.rigidbody.isKinematic = true;

			character.animator.SetBool("Is Visible", false);
		}

		public override void OnExit() {
			character.boxCollider.enabled = true;
			character.rigidbody.isKinematic = false;

			character.animator.SetBool("Is Visible", true);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (!character.hasTwin)
				return null;

			character.transform.position = new Vector2(character.twin.transform.position.x, character.transform.position.y);
			return null;
		}
	}
}

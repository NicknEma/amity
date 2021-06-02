using UnityEngine;

namespace Amity
{
    public class HiddenState : CharacterState
    {
        public HiddenState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.playerInput.enabled = false;
			character.collider.enabled = false;
			character.rigidbody.isKinematic = true;

			character.animator.SetBool("Is Visible", false);
		}

		public override void OnExit() {
			character.playerInput.enabled = true;
			character.collider.enabled = true;
			character.rigidbody.isKinematic = false;

			character.animator.SetBool("Is Visible", true);
		}

		public override CharacterState OnPhysicsUpdate() {
			character.transform.position = new Vector2(character.twin.transform.position.x, character.transform.position.y);
			return null;
		}
	}
}

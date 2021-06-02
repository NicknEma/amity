using UnityEngine;

namespace Amity
{
    public class FallingState : CharacterState
    {
		public FallingState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.animator.SetInteger("Vertical Speed", -1);
		}

		public override CharacterState OnPhysicsUpdate() {
			Vector2 speed = new Vector2(character.runSpeed * character.CurrentHorizontalInput, character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;

			character.animator.SetInteger("Horizontal Speed", (int) speed.x);

			if (character.footHitbox.isHitting)
				return new GroundedState(character);
			return null;
		}

		public override CharacterState OnPound(int input = 0) {
			return new PoundingState(character, input);
		}
	}
}

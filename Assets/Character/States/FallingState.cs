using UnityEngine;

namespace Amity
{
    public class FallingState : CharacterState
    {
		public FallingState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (character.footHitbox.isHitting)
				return new GroundedState(character);
			return null;
		}

		public override CharacterState OnCrouch() {
			return new PoundingState(character);
		}

		public override CharacterState OnRun(int direction) {
			Vector2 speed = new Vector2(character.runSpeed * direction, character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;
			return null;
		}
	}
}

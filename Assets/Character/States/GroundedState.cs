using UnityEngine;

namespace Amity
{
    public class GroundedState : CharacterState
    {
		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnCrouch() {
			return new CrouchingState(character);
		}

		public override CharacterState OnJump() {
			return new JumpingState(character);
		}

		public override CharacterState OnRun(int direction) {
			Vector2 speed = new Vector2(character.runSpeed * direction, character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;
			return null;
		}
	}
}

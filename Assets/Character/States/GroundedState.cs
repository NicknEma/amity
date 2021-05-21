using UnityEngine;

namespace Amity
{
    public class GroundedState : CharacterState
    {
		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.audioEmitter.PlaySelected("Landings");
			character.animator.SetInteger("Vertical Speed", 0);
			character.animator.SetBool("Is On Ground", true);
		}

		public override CharacterState OnJump() {
			return new JumpingState(character);
		}

		public override CharacterState OnRun(int direction) {
			Vector2 speed = new Vector2(character.runSpeed * direction, character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;

			character.animator.SetInteger("Horizontal Speed", (int) speed.x);
			return null;
		}
	}
}

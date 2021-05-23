using UnityEngine;

namespace Amity
{
    public class JumpingState : CharacterState
    {
		public JumpingState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.rigidbody.AddForce(new Vector2(0f, character.jumpForce * character.GravityScale), ForceMode2D.Impulse);

			character.audioEmitter.PlaySelected("Jumps");
			character.animator.SetInteger("Vertical Speed", 1);
		}

		public override CharacterState OnPhysicsUpdate() {
			Vector2 speed = new Vector2(character.runSpeed * character.CurrentHorizontalInput, character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;

			character.animator.SetInteger("Horizontal Speed", (int) speed.x);

			if (character.rigidbody.velocity.y * character.GravityScale < 0f)
				return new FallingState(character);
			return null;
		}

		public override CharacterState OnPound() {
			return new PoundingState(character);
		}
	}
}

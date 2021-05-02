using UnityEngine;

namespace Amity
{
    public class JumpingState : CharacterState
    {
		public JumpingState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
			character.rigidbody.AddForce(new Vector2(0f, character.jumpForce), ForceMode2D.Impulse);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (character.rigidbody.velocity.y < 0f)
				return new FallingState(character);
			return null;
		}

		public override CharacterState OnRun(int direction) {
			Vector2 speed = new Vector2(character.runSpeed * direction, character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;
			return null;
		}
	}
}

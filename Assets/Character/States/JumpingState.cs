using UnityEngine.InputSystem;
using UnityEngine;

namespace Amity
{
    public class JumpingState : CharacterState
    {
		public JumpingState(PlayerCharacter character) : base(character) {; }

		public override void OnEnter() {
			NotifyListeners(this);
			character.rigidbody.AddForce(new Vector2(0f, character.jumpForce), ForceMode2D.Impulse);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (character.rigidbody.velocity.y < 0f)
				return new FallingState(character);
			return null;
		}
	}
}

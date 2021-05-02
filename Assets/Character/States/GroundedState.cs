using UnityEngine.InputSystem;
using UnityEngine;

namespace Amity
{
    public class GroundedState : CharacterState
    {
		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnJump(InputValue inputValue = null) {
			return new JumpingState(character);
		}

		public override CharacterState OnRun(InputValue inputValue = null) {
			Vector2 speed = new Vector2(character.runSpeed * inputValue.Get<float>(), character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;
			return null;
		}
	}
}

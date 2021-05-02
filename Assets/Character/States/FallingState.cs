using UnityEngine.InputSystem;
using UnityEngine;

namespace Amity
{
    public class FallingState : CharacterState
    {
		public FallingState(PlayerCharacter character) : base(character) {; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnPhysicsUpdate() {
			if (character.footHitbox.isHitting)
				return new GroundedState(character);
			return null;
		}

		public override CharacterState OnRun(InputValue inputValue = null) {
			Vector2 speed = new Vector2(character.runSpeed * inputValue.Get<float>(), character.rigidbody.velocity.y);
			character.rigidbody.velocity = speed;
			return null;
		}
	}
}

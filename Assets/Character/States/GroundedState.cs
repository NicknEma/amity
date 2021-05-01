using UnityEngine.InputSystem;

namespace Amity
{
    public class GroundedState : CharacterState
    {
		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
		}

		public override CharacterState OnJump(InputValue inputValue = null) {
			// TODO: Implement coyote time
			return new JumpingState(character);
		}
	}
}

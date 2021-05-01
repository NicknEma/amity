using UnityEngine;

namespace Amity
{
    public class GroundedState : CharacterState
    {
		public GroundedState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			NotifyListeners(this);
		}
	}
}

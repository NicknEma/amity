using UnityEngine;

namespace Amity
{
    public class CrouchingState : CharacterState
    {
        public CrouchingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            NotifyListeners(this);
        }

		public override CharacterState OnLogicUpdate() {
            if (character.hasTwin)
                return new HiddenState(character);
            return null;
		}
	}
}

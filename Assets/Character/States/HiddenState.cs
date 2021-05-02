using UnityEngine;

namespace Amity
{
    public class HiddenState : CharacterState
    {
        public HiddenState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            NotifyListeners(this);
        }
    }
}

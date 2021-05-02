using UnityEngine;

namespace Amity
{
    public class FloatingState : CharacterState
    {
        public FloatingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            NotifyListeners(this);
        }
    }
}

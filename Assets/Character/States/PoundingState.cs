using UnityEngine;

namespace Amity
{
    public class PoundingState : CharacterState
    {
        public PoundingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            NotifyListeners(this);
        }
    }
}

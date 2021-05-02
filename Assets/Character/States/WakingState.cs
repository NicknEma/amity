using UnityEngine;

namespace Amity
{
    public class WakingState : CharacterState
    {
        public WakingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            NotifyListeners(this);
        }
    }
}

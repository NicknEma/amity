using UnityEngine;

namespace Amity
{
    public class HiddenState : CharacterState
    {
        public HiddenState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.animator.SetBool("Is Visible", false);
		}

		public override void OnExit() {
			character.animator.SetBool("Is Visible", true);
		}
	}
}

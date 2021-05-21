using UnityEngine;

namespace Amity
{
    public class FloatingState : CharacterState
    {
        public FloatingState(PlayerCharacter character) : base(character) { ; }

		public override void OnEnter() {
			character.animator.SetInteger("Vertical Speed", 0);
			character.animator.SetBool("Is On Ground", false);
		}

		public override CharacterState OnPound() {
			return new PoundingState(character);
		}
	}
}

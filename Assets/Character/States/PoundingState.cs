using UnityEngine;

namespace Amity
{
    public class PoundingState : CharacterState
    {
        public PoundingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            character.rigidbody.velocity = new Vector2(0f, -15f);

            character.animator.SetInteger("Vertical Speed", -2);
        }

		public override CharacterState OnPhysicsUpdate() {
            if (character.footHitbox.isHitting) {
                VirtualCameraShaker.Instance.Shake(.2f, .2f);
                if (character.hasTwin)
                    return new HiddenState(character);
                return new GroundedState(character);
			}
            return null;
		}
	}
}

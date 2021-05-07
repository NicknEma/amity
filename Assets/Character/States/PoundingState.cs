using UnityEngine;

namespace Amity
{
    public class PoundingState : CharacterState
    {
        public PoundingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            NotifyListeners(this);
            character.rigidbody.velocity = new Vector2(0f, -15f);
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

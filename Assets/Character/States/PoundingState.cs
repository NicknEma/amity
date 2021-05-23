using UnityEngine;

namespace Amity
{
    public class PoundingState : CharacterState
    {
        public PoundingState(PlayerCharacter character) : base(character) { ; }

        public override void OnEnter() {
            character.rigidbody.velocity = new Vector2(0f, -character.poundSpeed * character.GravityScale);

            character.animator.SetInteger("Vertical Speed", -2);
        }

		public override CharacterState OnPhysicsUpdate() {
            if (character.footHitbox.isHitting) {
                VirtualCameraShaker.Instance.Shake(.2f, .2f);
                var hit = Physics2D.Raycast((Vector2) character.transform.position + new Vector2(0, 1f), Vector2.up, float.Epsilon, 1 << LayerMask.NameToLayer("Switchers"));
                if (hit) {
                    character.twin.GetComponent<PlayerCharacter>().OnTwinHidden();
                    return new HiddenState(character);
                }

                /*
                if (character.hasTwin) {
                    character.twin.GetComponent<PlayerCharacter>().OnTwinHidden();
                    return new HiddenState(character);
                }
                */
                return new GroundedState(character);
			}
            return null;
		}
	}
}

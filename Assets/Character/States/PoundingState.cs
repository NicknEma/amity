using UnityEngine;

namespace Amity
{
    public class PoundingState : CharacterState
    {
        private readonly int input;
        
        public PoundingState(PlayerCharacter character, int input = 0) : base(character) {
            this.input = input;
        }

        public override void OnEnter() {
            Vector2 speed = new Vector2(character.poundSpeed * character.GravityScale * input,
                -character.poundSpeed * character.GravityScale);
            character.rigidbody.velocity = speed;

            character.animator.SetInteger("Vertical Speed", -2);
        }

		// TODO: Remove repeated code
		public override CharacterState OnPhysicsUpdate() {
            if (character.footHitbox.isHitting) {
                VirtualCameraShaker.Instance.Shake(.2f, .2f);

                if (!character.requiresSwitcher) {
                    character.twin.GetComponent<PlayerCharacter>().OnTwinHidden();
                    return new HiddenState(character);
                }

                var hit = Physics2D.Raycast((Vector2) character.transform.position + new Vector2(0, 1f),
                    Vector2.up, float.Epsilon, 1 << LayerMask.NameToLayer("Switchers"));

                if (hit) {
                    character.twin.GetComponent<PlayerCharacter>().OnTwinHidden();
                    return new HiddenState(character);
                }

                return new GroundedState(character);
			}
            return null;
		}
	}
}

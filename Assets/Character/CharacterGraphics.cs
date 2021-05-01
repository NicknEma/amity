using UnityEngine;

namespace Amity
{
    public class CharacterGraphics : MonoBehaviour
    {
		public PlayerCharacter character;

		[Header("Components")]
		public Animator animator;

		private void Start() {
			character.currentState.onStateEnter += PlayStateAnimation;
		}

		private void PlayStateAnimation(CharacterState state) {
			string stateName = state.GetType().Name;
			animator.SetTrigger(stateName);
		}
	}
}

/*
var @switch = new Dictionary<string, Action> {
				{ "", () => { } }
			};
*/

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

		public void SetFloat(string name, float value) {
			animator.SetFloat(name, value);
		}

		private void PlayStateAnimation(CharacterState state) {
			string stateName = state.GetType().Name;
			animator.Play(stateName);
		}
	}
}

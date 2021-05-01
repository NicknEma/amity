using UnityEngine;

namespace Amity
{
    public class CharacterAudio : MonoBehaviour
    {
		public PlayerCharacter character;

		[Header("Components")]
		public AudioHandler audioHandler;

		private void Start() {
			character.currentState.onStateEnter += PlayStateAudio;
		}

		private void PlayStateAudio(CharacterState state) {
			string stateName = state.GetType().Name;
			audioHandler.SetTrigger(stateName);
		}
	}
}

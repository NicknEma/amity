using UnityEngine;

namespace Amity
{
    public class CharacterAudio : MonoBehaviour
    {
		public PlayerCharacter character;

		[Header("Components")]
		public AudioSource audioSource;

		[Header("Audio Objects")]
		public AudioObject jumps;
		public AudioObject footsteps;
		public AudioObject landings;
		public AudioObject pounds;
		public AudioObject appearances;

		private string previousState;

		private void Start() {
			character.currentState.onStateEnter += PlayStateAudio;
		}

		// Used by animation events for footsteps
		public void PlayFromObject(AudioObject aObject) {
			aObject.PlayClip(audioSource);
		}

		private void PlayStateAudio(CharacterState state) {
			string stateName = state.GetType().Name;
			switch (stateName) {
				case "GroundedState": {
					switch (previousState) {
						case "FallingState": {
							landings.PlayClip(audioSource);
							break;
						}
					case "PoundingState": {
							pounds.PlayClip(audioSource);
							break;
						}
					}
					break;
				}
				case "JumpingState": { jumps.PlayClip(audioSource); break; }
				case "WakingState": { appearances.PlayClip(audioSource); break; }
				default: { break; }
			}
			previousState = stateName;
		}
	}
}

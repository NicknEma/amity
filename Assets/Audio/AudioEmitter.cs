using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

namespace Amity
{
    /// <summary>
    /// Enables playing multiple AudioClips from the same AudioSource (MonoBehaviour).
    /// </summary>
    public class AudioEmitter : MonoBehaviour
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the Audio Mixer Group used by the controlled Audio Source.
        /// </summary>
        public AudioMixerGroup Output {
            get {
                return output;
			}
            set {
                output = value;
                source.outputAudioMixerGroup = output;
			}
		}

        #endregion

        #region FIELDS

        [SerializeField, Tooltip("Set whether the sound should play through an Audio Mixer first or directly to the Audio Listener.")]
        private AudioMixerGroup output;

        [SerializeField, Tooltip("Array of Audio Groups that the Game Object will be able to play.")]
        private AudioGroup[] audioGroups;

        private Dictionary<string, AudioGroup> clips;
        
        private AudioSource source;

		#endregion

		#region PUBLIC_METHODS

        /// <summary>
        /// Plays an Audio Clip from a dictionary of Audio Groups.
        /// </summary>
        /// <param name="clip">The keyword used for searching the clip in the dictionary.</param>
		public void PlaySelected(string clip) {
            if (clips.TryGetValue(clip, out var audioGroup))
                audioGroup.PlayFrom(source);
        }

		#endregion

		#region PRIVATE_METHODS

		private void Awake() {
            AddSource();
            InitializeDictionary();
        }

		private void OnEnable() {
            source.mute = false;
		}

		private void OnDisable() {
            source.mute = true;
		}

		private void OnDestroy() {
            Destroy(source);
		}

		private void AddSource() {
            source = gameObject.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = output;
        }

		private void InitializeDictionary() {
            clips = new Dictionary<string, AudioGroup>();
            for (int i = 0; i < audioGroups.Length; i++)
                clips.Add(audioGroups[i].name, audioGroups[i]);
        }

		#endregion
	}
}

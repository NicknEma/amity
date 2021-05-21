using System.Collections.Generic;
using UnityEngine;

namespace Amity
{
    /// <summary>
    /// MonoBehaviour used to play multiple AudioClips from the same AudioSource.
    /// </summary>
    public class AudioEmitter : MonoBehaviour
    {
		#region PUBLIC_FIELDS

        /// <summary>
        /// Field used for assigning AudioGroups from the Inspector
        /// </summary>
		public AudioGroup[] audioAssets;

		#endregion

		#region PRIVATE_FIELDS

		private Dictionary<string, AudioGroup> clips;
        
        private AudioSource source;

		#endregion

		#region PUBLIC_METHODS

        /// <summary>
        /// Plays an Audio Clip, using the 'clip' argument as a keyword.
        /// </summary>
        /// <param name="clip">The keyword used for searching the clip.</param>
		public void PlaySelected(string clip) {
            if (clips.TryGetValue(clip, out var audioGroup))
                audioGroup.PlayFrom(source);
        }

		#endregion

		#region PRIVATE_METHODS

		private void Awake() {
            source = gameObject.AddComponent<AudioSource>();
            InitializeDictionary();
        }
        
        private void InitializeDictionary() {
            clips = new Dictionary<string, AudioGroup>();
            for (int i = 0; i < audioAssets.Length; i++)
                clips.Add(audioAssets[i].name, audioAssets[i]);
        }

		#endregion
	}
}

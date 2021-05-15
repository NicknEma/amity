using UnityEngine;

namespace Amity
{
    [System.Serializable]
    public class AudioGroup
    {
        public AudioSelectMode selectMode;

        [Range(0.0f, 1.0f)]
        public float volume;
        public AudioClip[] clips;

		private int lastPlayed = -1;

		public void PlayClip(AudioSource source) {
			
			int index = -1;
			switch (selectMode) {
				case AudioSelectMode.Random: {
					do {
						index = Random.Range(0, clips.Length);
					} while (index == lastPlayed);
					break;
				}
				case AudioSelectMode.Sequence: {
					lastPlayed++;
					if (lastPlayed == clips.Length)
						lastPlayed = 0;
					index = lastPlayed;
					break;
				}
			}

			source.PlayOneShot(clips[index], volume);
		}
	}
}

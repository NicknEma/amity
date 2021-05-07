using UnityEngine;

namespace Amity
{
    [CreateAssetMenu(order = 51)]
    public class AudioObject : ScriptableObject
    {
		public enum SelectMode { Random, Sequence }
		public SelectMode selectMode;

		[Range(0.0f, 1.0f)]
		public float volume;
		public AudioClip[] clips;

		private int lastPlayed = -1;

		public void PlayClip(AudioSource source) {
			int index = -1;
			switch (selectMode) {
				case SelectMode.Random: {
					do {
						index = Random.Range(0, clips.Length);
					} while (index != lastPlayed);
					break;
				}
				case SelectMode.Sequence: {
					lastPlayed++;
					index = lastPlayed;
					break;
				}
			}
			source.PlayOneShot(clips[index], volume);
		}
	}
}

using UnityEngine;

namespace Amity
{
	[CreateAssetMenu(order = 51)]
	public class AudioGroup : ScriptableObject
    {
		#region PUBLIC_FIELDS

		/// <summary>
		/// The method used to select an AudioClip from the <c>clips</c> array.
		/// </summary>
		public AudioSelectMode selectMode;

		/// <summary>
		/// The volume at which the AudioClip will be played.
		/// </summary>
        [Range(0.0f, 1.0f)]
		public float volume = 0.5f;

		/// <summary>
		/// Array containing all the possible clips that can be played by this Group.
		/// </summary>
		[Space]
        public AudioClip[] clips;

		#endregion

		#region PRIVATE_FIELDS

		private int lastPlayed = -1;

		#endregion

		#region PUBLIC_METHODS

		/// <summary>
		/// Plays an AudioClip from the passed AudioSource. The clip is automatically
		/// selected from the class' <c>clips</c> field.
		/// </summary>
		/// <param name="source">The AudioSource from which to play the AudioClip.</param>
		public void PlayFrom(AudioSource source) {
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

		#endregion
	}
}

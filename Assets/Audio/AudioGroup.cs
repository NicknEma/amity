using UnityEngine;

namespace Amity
{
	/// <summary>
	/// Manages a set of AudioClips that all represent the same sound type (ScriptableObject)
	/// </summary>
	[CreateAssetMenu(order = 51)]
	public class AudioGroup : ScriptableObject
    {
		#region PROPERTIES

		/// <summary>
		/// Gets or sets how the next Audio Clip will be chosen from the Group.
		/// </summary>
		public AudioSelectMode SelectMode {
			get {
				return selectMode;
			}
			set {
				selectMode = value;
			}
		}

		/// <summary>
		/// Gets or sets the volume at which to play the Audio Clips.
		/// </summary>
		public float Volume {
			get {
				return volume;
			}
			set {
				volume = value;
			}
		}

		#endregion

		#region FIELDS

		[SerializeField, Tooltip("The rule that states how the next Audio Clip will be chosen from the Group.")]
		private AudioSelectMode selectMode;

		[SerializeField, Range(0.0f, 1.0f), Tooltip("The volume at which to play the Audio Clips.")]
		private float volume = 0.5f;

		[SerializeField, Space, Tooltip("Array of all the possible clips that can be played by this Audio Group.")]
		private AudioClip[] clips;

		private int lastPlayed = -1;

		#endregion

		#region PUBLIC_METHODS

		/// <summary>
		/// Plays an Audio Clip from the passed Audio Source. The clip is automatically
		/// selected from the class' <c>clips</c> field.
		/// </summary>
		/// <param name="source">The Audio Source from which to play the Audio Clip.</param>
		public void PlayFrom(AudioSource source) {
			if (clips.Length == 0)
				return;

			int index = 0;
			switch (selectMode) {
				case AudioSelectMode.Random: {
					do {
						index = Random.Range(0, clips.Length-1);
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
				default: return;
			}

			source.PlayOneShot(clips[index], volume);
		}

		#endregion
	}
}

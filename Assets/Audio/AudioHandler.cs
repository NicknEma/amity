using System.Collections.Generic;
using UnityEngine;

namespace Amity
{
    public class AudioHandler : MonoBehaviour
    {
        public AudioAsset[] audioAssets;

        private Dictionary<string, AudioGroup> clips;
        
        private AudioSource source;

        private void Awake() {
            source = Camera.main.GetComponent<AudioSource>();
            clips = new Dictionary<string, AudioGroup>();
            for (int i = 0; i < audioAssets.Length; i++)
                clips.Add(audioAssets[i].assetName, audioAssets[i].group);
        }

        public void PlayGlobal(string clipName) {
            clips[clipName].PlayClip(source);
		}
    }
}

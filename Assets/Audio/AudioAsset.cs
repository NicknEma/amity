using UnityEngine;

namespace Amity
{
    [CreateAssetMenu(order = 51)]
    public class AudioAsset : ScriptableObject
    {
        public string assetName;
        public AudioGroup group;
    }
}

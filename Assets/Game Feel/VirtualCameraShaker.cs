using UnityEngine;
using Cinemachine;
using System.Collections;

namespace Amity
{
    public class VirtualCameraShaker : MonoBehaviour
    {
        public static VirtualCameraShaker Instance { get; private set; }
        
        [Header("Components")]
        public new CinemachineVirtualCamera camera;

		private void Awake() {
            Instance = this;
		}

		public void Shake(float intensity, float time) {
            StartCoroutine(Shake_(intensity, time));
		}

        private IEnumerator Shake_(float intensity, float time) {
            var a = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            a.m_AmplitudeGain = intensity;
            yield return new WaitForSeconds(time);
            a.m_AmplitudeGain = 0f;
		}
    }
}

using UnityEngine;
using Cinemachine;

namespace Amity
{
	public class VirtualCameraPriorityUpdater : MonoBehaviour
    {
		#region FIELDS

		[SerializeField]
		private CinemachineVirtualCamera camera;

		[SerializeField, Space]
		private PlayerCharacter target;

		#endregion

		#region PRIVATE_METHODS

		private void Update() {
			if (!enabled || Time.frameCount % 10 != 0)
				return;

			if (target.CurrentState.GetType() == typeof(HiddenState)) {
				camera.m_Priority = 0;
			} else {
				camera.m_Priority = 10;
			}
		}

		#endregion
	}
}

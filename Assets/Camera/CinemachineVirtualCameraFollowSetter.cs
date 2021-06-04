using UnityEngine;
using Cinemachine;

namespace Amity.Assets.Camera
{
	public class CinemachineVirtualCameraFollowSetter : MonoBehaviour
	{
		public CinemachineVirtualCamera virtualCamera;
		
		public void SetFollow(Transform target) {
			if (!enabled)
				return;

			virtualCamera.m_Follow = target;
		}
	}
}
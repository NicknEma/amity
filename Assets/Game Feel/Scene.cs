using UnityEngine;
using Cinemachine;

namespace Amity.Assets.Game_Feel
{
	static class Scene
	{
		/// <summary>
		/// Gets a reference to the scene's main camera (cached after first use).
		/// </summary>
		public static Camera MainCamera {
			get {
				if (mainCamera == null)
					mainCamera = Camera.main;
				return mainCamera;
			}
		}

		private static Camera mainCamera;

		/// <summary>
		/// Gets a reference to the scene's main camera (not cached).
		/// </summary>
		public static CinemachineVirtualCamera ActiveVirtualCamera {
			get {
				return (CinemachineVirtualCamera) MainCamera.GetComponent<CinemachineBrain>().ActiveVirtualCamera;
			}
		}
	}
}

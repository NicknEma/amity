using UnityEngine;
using Cinemachine;

namespace Amity
{
	static class Scene
	{
		#region PROPERTIES

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

		/// <summary>
		/// Gets a reference to the scene's main Impulse Source (cached after first use).
		/// </summary>
		public static CinemachineImpulseSource ImpulseSource {
			get {
				if (impulseSource == null)
					impulseSource = Object.FindObjectOfType<CinemachineImpulseSource>();
				return impulseSource;
			}
		}

		#endregion

		#region FIELDS

		private static Camera mainCamera;

		private static CinemachineImpulseSource impulseSource;

		#endregion
	}
}

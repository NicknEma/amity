using UnityEngine;

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

		#endregion

		#region FIELDS

		private static Camera mainCamera;

		#endregion
	}
}

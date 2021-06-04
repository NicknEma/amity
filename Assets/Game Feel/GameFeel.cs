using UnityEngine;
using Cinemachine;

namespace Amity
{
	public static class GameFeel
	{
		public static void Shake(this Camera camera) {
			Scene.ImpulseSource.GenerateImpulse();
		}
	}
}
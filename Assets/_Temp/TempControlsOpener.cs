using UnityEngine;
using UnityEngine.UI;

namespace Amity
{
    public class TempControlsOpener : MonoBehaviour
    {
        public GameObject canvas;

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Escape))
				canvas.SetActive(!canvas.activeInHierarchy);
		}
	}
}

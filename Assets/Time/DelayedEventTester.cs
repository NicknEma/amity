using UnityEngine;

namespace Amity
{
    public class DelayedEventTester : MonoBehaviour
    {
		public DelayedEvent delayedEvent;

		private void Start() {
			delayedEvent.Invoke();
		}

		public void PrintOnEnd() { Debug.Log("Event raised"); }
    }
}

using UnityEngine.Events;
using System.Timers;

namespace Amity
{
	[System.Serializable]
	public class DelayedEvent
    {
		public float delay = 5f;
		public UnityEvent @event;

		public void Invoke() {
			Timer timer = new Timer(delay);
			timer.Elapsed += EndInvoke;
			timer.AutoReset = false;
			timer.Enabled = true;
		}

		private void EndInvoke(object source, ElapsedEventArgs e) { @event.Invoke(); }
    }
}

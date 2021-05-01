using UnityEngine.Events;
using UnityEngine;

namespace Amity
{
    public class TimerController : MonoBehaviour
    {
		public float duration = 5f;
		public bool startOnAwake;
		public UnityEvent onTimerEnd;

		private Timer timer;
		private bool isTimerActive;

		private void Awake() {
			if (startOnAwake)
				StartTimer();
		}

		private void Update() {
			if (isTimerActive && timer != null) {
				timer.Tick(Time.deltaTime);
				if (timer.RemainingTime == 0f)
					isTimerActive = false;
			}
		}

		public void StartTimer() {
			timer = new Timer(duration);
			timer.onTimerEnd += onTimerEnd.Invoke;
			isTimerActive = true;
		}
	}
}

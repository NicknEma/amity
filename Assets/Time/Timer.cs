using System;

namespace Amity
{
    public class Timer
    {
		public readonly float duration;
		public float RemainingTime { get; private set; }

		public event Action onTimerEnd;

		public Timer(float duration) {
			this.duration = duration;
			RemainingTime = duration;
		}

		public void Tick(float deltaTime) {
			RemainingTime -= deltaTime;
			if (RemainingTime <= 0f) {
				onTimerEnd?.Invoke();
			}
			RemainingTime = 0f;
		}
    }
}

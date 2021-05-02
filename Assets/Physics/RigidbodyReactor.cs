using UnityEngine.Events;
using UnityEngine;

namespace Amity
{
    public class RigidbodyReactor : MonoBehaviour
    {
        public Rigidbody2D target;

        public FloatEvent onHorizontalVelocityChanged;

        private Vector2 currentVelocity;

		private void FixedUpdate() {
            Vector2 newVelocity = target.velocity;
            if (Mathf.Abs(newVelocity.x - currentVelocity.x) < float.Epsilon) {
                onHorizontalVelocityChanged.Invoke("Horizontal Velocity", newVelocity.x);
                currentVelocity = newVelocity;
            }
		}
	}

    [System.Serializable]
    public class FloatEvent : UnityEvent<string, float> { }
}

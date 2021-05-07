using UnityEngine;

namespace Amity
{
    public class FlippingController : MonoBehaviour
    {
        [Header("Components")]
        public new Rigidbody2D rigidbody;
        public Animator animator;

        [Header("Animator Variables")]
        public string intName;

        private int currentVelocity;

		private void FixedUpdate() {
            int newVelocity = (int) rigidbody.velocity.x;
            if (newVelocity != currentVelocity) {
                animator.SetInteger(intName, newVelocity);
                currentVelocity = newVelocity;
			}
		}
	}
}

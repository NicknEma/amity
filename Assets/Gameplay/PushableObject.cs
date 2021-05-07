using UnityEngine;

namespace Amity
{
    public class PushableObject : MonoBehaviour
    {
        [Header("Components")]
        public OverlapChecker2D playerChecker;
        public new Rigidbody2D rigidbody;

		private void FixedUpdate() {
            if (!playerChecker.isHitting)
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
		}
	}
}

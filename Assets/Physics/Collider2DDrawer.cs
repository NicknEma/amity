using UnityEngine;

namespace Amity
{
#if UNITY_EDITOR
    public abstract class Collider2DDrawer : MonoBehaviour
    {
        protected static readonly Color defaultColliderColor = new Color(135, 255, 170);

        public Color lineColor = defaultColliderColor;
    }
#endif
}

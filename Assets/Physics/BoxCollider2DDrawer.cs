using UnityEngine;

namespace Amity
{
#if UNITY_EDITOR
	[ExecuteAlways]
    public class BoxCollider2DDrawer : MonoBehaviour
    {
		private static readonly Color defaultColliderColor = new Color(135, 255, 170);

		public Color lineColor = defaultColliderColor;

		public BoxCollider2D[] targets;

		private void Awake() {
			if (targets == null)
				targets = new BoxCollider2D[0];
		}

		private void Update() {
			for (int i = 0; i < targets.Length; i++) {
				if (targets[i] == null)
					continue;
				// BoxCollider2D target = targets[i];
				DrawBox(targets[i].transform.position, targets[i].size / 2, lineColor);
			}
		}

		private void DrawBox(Vector2 point, Vector2 size, Color color) {
			Vector2[] points = new Vector2[] {
			new Vector2(point.x + size.x, point.y + size.y),
			new Vector2(point.x - size.x, point.y + size.y),
			new Vector2(point.x - size.x, point.y - size.y),
			new Vector2(point.x + size.x, point.y - size.y),
			new Vector2(point.x + size.x, point.y + size.y)
		};
			for (int i = 0; i < points.Length - 1; i++) {
				Debug.DrawLine(points[i], points[i + 1], color);
			}
		}
	}

	/*
	[System.Serializable]
	public class BoxDisplay
	{
		public BoxCollider2D boxCollider;
		public Color displayColor = new Color(135, 255, 170);
	}
	*/
#endif
}

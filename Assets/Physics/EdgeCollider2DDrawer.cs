using UnityEngine;

namespace Amity
{
#if UNITY_EDITOR
    [ExecuteAlways]
    public class EdgeCollider2DDrawer : Collider2DDrawer
    {
        public EdgeCollider2D[] targets;

        private void Awake() {
            if (targets == null)
                targets = new EdgeCollider2D[0];
        }

        private void Update() {
            for (int i = 0; i < targets.Length; i++) {
                if (targets[i] == null)
                    continue;
                Vector2[] path = targets[i].points;
                for (int j = 0; j < path.Length; j++)
                    path[j] += (Vector2) targets[i].transform.position;
                DrawEdge(path, lineColor);
            }
        }

        private void DrawEdge(Vector2[] edge, Color color) {
            for (int i = 0; i < edge.Length - 1; i++) {
                Debug.DrawLine(edge[i], edge[i + 1], color);
            }
        }
    }
#endif
}

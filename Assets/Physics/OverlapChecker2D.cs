using UnityEngine;

[AddComponentMenu("Physics 2D/Overlap Checker 2D"), ExecuteAlways]
public class OverlapChecker2D : PhysicsChecker2D
{
    public Vector2 offset = Vector2.zero;
    public Vector2 size = new Vector2(1.0f, 1.0f);

    [Space(15)]
    public UnityCollisionEvent onOverlapEnter;
    public UnityCollisionEvent onOverlapExit;

    public bool drawHitbox = true;

    private bool wasHitting;

#if UNITY_EDITOR
    private void Update() {
        if (Application.isPlaying)
            return;
        FixedUpdate();
    }
#endif

    private void FixedUpdate() {
        Collider2D other = OverlapBox((Vector2) transform.position + offset, size / 2, drawHitbox);
        isHitting = other;

        if (isHitting && !wasHitting)
            onOverlapEnter.Invoke(other);
        if (!isHitting && wasHitting)
            onOverlapExit.Invoke(other);

        wasHitting = isHitting;
    }

    private Collider2D OverlapBox(Vector2 point, Vector2 size, bool drawHitbox = true) {
        Collider2D hit = null;
        hit = Physics2D.OverlapArea(point + size, point - size, layerMask);
#if UNITY_EDITOR
        if (drawHitbox) {
            Color color = hit ? Color.red : Color.green;
            DrawBox(point, size, color);
        }
#endif
        return hit;
    }

#if UNITY_EDITOR
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
#endif
}

using UnityEngine;

[AddComponentMenu("Physics 2D/Collision Checker 2D")]
public class CollisionChecker2D : PhysicsChecker2D
{
    public new Collider2D collider;

    [Space(15)]
    public UnityCollisionEvent onCollisionEnter;
    public UnityCollisionEvent onCollisionExit;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!isEnabled || (collider.isTrigger || collision.collider.isTrigger) || layerMask != (layerMask | (1 << collision.gameObject.layer))) return;
        onCollisionEnter.Invoke(collision.collider);
        isHitting = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (!isEnabled || (collider.isTrigger || collision.collider.isTrigger) || layerMask != (layerMask | (1 << collision.gameObject.layer))) return;
        onCollisionExit.Invoke(collision.collider);
        isHitting = false;
    }
}

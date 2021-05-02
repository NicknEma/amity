using UnityEngine;

[AddComponentMenu("Physics 2D/Trigger Checker 2D")]
public class TriggerChecker2D : PhysicsChecker2D
{
    public new Collider2D collider;
    
    [Space(15)]
    public UnityCollisionEvent onTriggerEnter;
    public UnityCollisionEvent onTriggerExit;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!enabled || (!collider.isTrigger && !other.isTrigger) || layerMask != (layerMask | (1 << other.gameObject.layer))) return;
        onTriggerEnter.Invoke(other);
        isHitting = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!enabled || (!collider.isTrigger && !other.isTrigger) || layerMask != (layerMask | (1 << other.gameObject.layer))) return;
        onTriggerExit.Invoke(other);
        isHitting = false;
    }
}

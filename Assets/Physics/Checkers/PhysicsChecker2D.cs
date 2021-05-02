using UnityEngine;
using UnityEngine.Events;

public abstract class PhysicsChecker2D : MonoBehaviour
{
    public LayerMask layerMask;

    protected bool isEnabled = true;

    public bool isHitting { get; protected set; }

    private void OnEnable() { isEnabled = true; }

    private void OnDisable() { isEnabled = false; }

    [System.Serializable] public class UnityCollisionEvent : UnityEvent<Collider2D> { }
}

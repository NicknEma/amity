using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TriggerChecker2D))]
public class TriggerChecker2DEditor : Editor
{
    private const string message =
        "The referenced collider is not a trigger. " +
        "Collision events will only be called when the other collider is a trigger";

    private TriggerChecker2D current { get { return (TriggerChecker2D) target; } }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (current.collider != null && !current.collider.isTrigger) {
            EditorGUILayout.HelpBox(message, MessageType.Info);
        }
    }
}

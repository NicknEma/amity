using UnityEditor;

[CustomEditor(typeof(CollisionChecker2D))]
public class CollisionChecker2DEditor : Editor
{
    private const string message =
        "The referenced collider is a trigger. " +
        "To call the specified events, either use a normal collider or use a 'TriggerChecker2D' component.";

    private CollisionChecker2D current { get { return (CollisionChecker2D) target; } }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (current.collider != null && current.collider.isTrigger) {
            EditorGUILayout.HelpBox(message, MessageType.Warning);
        }
    }
}

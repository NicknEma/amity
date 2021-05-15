using UnityEditor;
using UnityEngine;

namespace Amity
{
    [CustomPropertyDrawer(typeof(AudioAsset))]
    public class AudioAssetDrawer : PropertyDrawer
    {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginProperty(position, label, property);

			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			int indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect idRect = new Rect(position.x - position.width * 0.35f, position.y, position.width * 0.35f + 5, position.height);
			Rect groupRect = new Rect(position.x + 10, position.y, position.width - 1, position.height);

			SerializedProperty id = property.FindPropertyRelative("assetName");
			SerializedProperty group = property.FindPropertyRelative("group");

			EditorGUI.PropertyField(idRect, id, GUIContent.none);
			EditorGUI.PropertyField(groupRect, group, GUIContent.none);

			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}
	}
}

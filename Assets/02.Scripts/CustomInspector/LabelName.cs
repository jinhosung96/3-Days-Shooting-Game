using UnityEngine;
using UnityEditor;

namespace JHS
{
    /// <summary>
    /// 매개변수로 받은 문자열을 변수명으로 변경
    /// </summary>
    public class LabelNameAttribute : PropertyAttribute
    {
        public string m_newName { get; private set; }

        public LabelNameAttribute(string _labelName)
        {
            m_newName = _labelName;
        }
    }
#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(LabelNameAttribute))]
    public class NamePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            LabelNameAttribute labelNameAttribute = (LabelNameAttribute)this.attribute;
            _label.text = labelNameAttribute.m_newName;
            EditorGUI.PropertyField(_position, _property, _label);
        }
    }

#endif
}

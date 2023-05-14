#region #info || License Information || #endinfo
// This code is licensed under the VectorTyping Library License.
///
///  ,
///  | MIT License
///  | 
///  | Copyright (c) 2023-2024 FCSplayz and Unity Technologies
///  | 
///  | Permission is hereby granted, free of charge, to any person obtaining a copy
///  | of this library and associated documentation files (the "Library"), to deal
///  | in the Library or any derivative works thereof with the following conditions
///  '
///
// Refer to the accompanying 'LICENSE.md' file for more information.
#endregion

#region Assembly VectorTyping.Drawers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
#endregion

using UnityEditor;
using UnityEngine;

namespace VectorTyping.Drawers
{
	[CustomPropertyDrawer(typeof(Vector4Int))]
	internal class Vector4IntDrawer : PropertyDrawer
	{
		private const float Spacing = 20f;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			SerializedProperty xProp = property.FindPropertyRelative("m_X");
			SerializedProperty yProp = property.FindPropertyRelative("m_Y");
			SerializedProperty zProp = property.FindPropertyRelative("m_Z");
			SerializedProperty wProp = property.FindPropertyRelative("m_W");

			float labelWidth = EditorGUIUtility.labelWidth;
			float fieldWidth = (position.width - labelWidth + (Spacing * 1.45f)) / 4f;
			float lineHeight = EditorGUIUtility.singleLineHeight;

			Rect labelRect = new Rect(position.x, position.y, labelWidth, lineHeight);
			Rect xRect = new Rect(labelRect.xMax - 105f, position.y + lineHeight, fieldWidth, lineHeight);
			Rect yRect = new Rect(xRect.xMax + Spacing, position.y + lineHeight, fieldWidth, lineHeight);
			Rect zRect = new Rect(yRect.xMax + Spacing, position.y + lineHeight, fieldWidth, lineHeight);
			Rect wRect = new Rect(zRect.xMax + Spacing, position.y + lineHeight, fieldWidth, lineHeight);

			EditorGUI.LabelField(labelRect, label);
			EditorGUI.LabelField(xRect, "X");
			EditorGUI.LabelField(yRect, "Y");
			EditorGUI.LabelField(zRect, "Z");
			EditorGUI.LabelField(wRect, "W");

			xProp.intValue = EditorGUI.IntField(new Rect(xRect.x + 12f, xRect.y, xRect.width, lineHeight), GUIContent.none, xProp.intValue);
			yProp.intValue = EditorGUI.IntField(new Rect(yRect.x + 12f, yRect.y, yRect.width, lineHeight), GUIContent.none, yProp.intValue);
			zProp.intValue = EditorGUI.IntField(new Rect(zRect.x + 12f, zRect.y, zRect.width, lineHeight), GUIContent.none, zProp.intValue);
			wProp.intValue = EditorGUI.IntField(new Rect(wRect.x + 16.5f, wRect.y, wRect.width, lineHeight), GUIContent.none, wProp.intValue);

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float lineHeight = EditorGUIUtility.singleLineHeight;
			return base.GetPropertyHeight(property, label) + lineHeight;
		}
	}
}

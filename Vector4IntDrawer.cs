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

#region Assembly VectorTyping, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// The VectorTyping library can be found at https://github.com/FCSplayz/VectorTyping.
#endregion

using UnityEditor;
using UnityEngine;

namespace VectorTyping.Drawers
{
	/// <summary>
	///     Allows Vector4Ints to be shown in the Inspector like normal Vector types.
	/// </summary>
	[CustomPropertyDrawer(typeof(Vector4Int))]
	internal sealed class Vector4IntDrawer : PropertyDrawer
	{
		private const float Spacing = 20f;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			// Define the necessary variables.
			SerializedProperty xProp = property.FindPropertyRelative("m_X");
			SerializedProperty yProp = property.FindPropertyRelative("m_Y");
			SerializedProperty zProp = property.FindPropertyRelative("m_Z");
			SerializedProperty wProp = property.FindPropertyRelative("m_W");

			float labelWidth = EditorGUIUtility.labelWidth - 1f;
			float inspectorWidth = EditorGUIUtility.currentViewWidth;
			float fieldWidth = (position.width - EditorGUIUtility.labelWidth + (Spacing * 1.45f)) / 4f;
			float lineHeight = EditorGUIUtility.singleLineHeight;

			float rectHeight = 0f;
			if (inspectorWidth <= 475f)
				rectHeight = EditorGUIUtility.singleLineHeight;

			// Create the labels and fields in the Inspector.
			Rect labelRect = new Rect(position.x, position.y, labelWidth, lineHeight);
			Rect xRect = new Rect(labelRect.xMax - 105f, position.y + rectHeight, fieldWidth, lineHeight);
			Rect yRect = new Rect(xRect.xMax + Spacing, position.y + rectHeight, fieldWidth, lineHeight);
			Rect zRect = new Rect(yRect.xMax + Spacing, position.y + rectHeight, fieldWidth, lineHeight);
			Rect wRect = new Rect(zRect.xMax + Spacing, position.y + rectHeight, fieldWidth, lineHeight);

			if (inspectorWidth <= 475f)
				labelRect.width = inspectorWidth - Spacing * 1.125f + 1f;
			else if (inspectorWidth > 475f)
				labelRect.width = inspectorWidth - (xRect.width + yRect.width + zRect.width + wRect.width)
					* 1.3125f - Spacing / 3f + inspectorWidth / fieldWidth * 2 - 11f + (inspectorWidth - 475f) / 6f;
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
			float inspectorWidth = EditorGUIUtility.currentViewWidth;
			float rectHeight = 0f;
			if (inspectorWidth <= 475f)
				rectHeight = EditorGUIUtility.singleLineHeight;
			return base.GetPropertyHeight(property, label) + rectHeight;
		}
	}
}

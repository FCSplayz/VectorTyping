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

using System;
using System.Collections.Generic;
using UnityEngine;

namespace VectorTyping.Extensions
{
	/// <summary>
	///     Class containing extensions for the Vector4Int struct.
	/// </summary>
	public static class Vector4IntExtensions
	{
		/// <summary>
		///     Copies this integer array's values and returns them in the form of a Vector4Int.
		///     <para>For the conversion to work, the length of this integer array must be equal to 4.</para>
		/// </summary>
		public static Vector4Int ToVector4Int(this int[] arr)
		{
			if (arr.Length == 4)
				return new Vector4Int(arr[0], arr[1], arr[2], arr[3]);
			else
				throw new ArgumentException("The length of this integer array must be equal to 4 when converting to Vector4Int.", nameof(arr));
		}

		/// <summary>
		///     Copies this integer array's values and returns them in the form of a Vector4Int.
		///     <para>For the conversion to work, the length of the integer list must be a multiple of 4.</para>
		/// </summary>
		public static Vector4Int[] ToVector4IntArray(this List<int> lst)
		{
			if (lst.Count % 4 != 0)
				throw new ArgumentException("The item count of this integer list must be a multiple of 4.", nameof(lst));

			int numVectors = lst.Count / 4;
			Vector4Int[] vectorArray = new Vector4Int[numVectors];

			for (int i = 0; i < numVectors; i++)
			{
				int startIndex = i * 4;
				vectorArray[i] = new Vector4Int(lst[startIndex], lst[startIndex + 1], lst[startIndex + 2], lst[startIndex + 3]);
			}

			return vectorArray;
		}

		public static List<Vector4Int> ToVector4IntList(this int[] arr)
		{
			if (arr.Length % 4 != 0)
				throw new ArgumentException("The length of this integer array must be a multiple of 4.", nameof(arr));

			int numVectors = arr.Length / 4;
			List<Vector4Int> vectorList = new List<Vector4Int>(numVectors);

			for (int i = 0; i < numVectors; i++)
			{
				int startIndex = i * 4;
				vectorList.Add(new Vector4Int(arr[startIndex], arr[startIndex + 1], arr[startIndex + 2], arr[startIndex + 3]));
			}

			return vectorList;
		}
	}
}

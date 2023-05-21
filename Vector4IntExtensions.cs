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

namespace VectorTyping.Extensions
{
	/// <summary>
	///     Static class containing extensions for the Vector4Int type struct.
	/// </summary>
	public static class Vector4IntExtensions
	{
		// To 'Vector4Int'
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
		///     Copies this integer list's values and returns them in the form of a Vector4Int array.
		///     <para>For the conversion to work, the item count of this integer list must be a multiple of 4.</para>
		/// </summary>
		public static Vector4Int[] ToVector4IntArray(this List<int> lst)
		{
			if (lst.Count % 4 != 0)
				throw new ArgumentException("The item count of this integer list must be a multiple of 4 when converting to a Vector4Int array.", nameof(lst));

			int numVectors = lst.Count / 4;
			Vector4Int[] vectorArray = new Vector4Int[numVectors];

			for (int i = 0; i < numVectors; i++)
			{
				int startIndex = i * 4;
				vectorArray[i] = new Vector4Int(lst[startIndex], lst[startIndex + 1], lst[startIndex + 2], lst[startIndex + 3]);
			}

			return vectorArray;
		}

		/// <summary>
		///     Copies this integer array's values and returns them in the form of a Vector4Int list.
		///     <para>For the conversion to work, the length of this integer array must be a multiple of 4.</para>
		/// </summary>
		public static List<Vector4Int> ToVector4IntList(this int[] arr)
		{
			if (arr.Length % 4 != 0)
				throw new ArgumentException("The length of this integer array must be a multiple of 4 when converting to a Vector4Int list.", nameof(arr));

			int numVectors = arr.Length / 4;
			List<Vector4Int> vectorList = new List<Vector4Int>();

			for (int i = 0; i < numVectors; i++)
			{
				int startIndex = i * 4;
				vectorList.Add(new Vector4Int(arr[startIndex], arr[startIndex + 1], arr[startIndex + 2], arr[startIndex + 3]));
			}

			return vectorList;
		}
		/// <summary>
		///     Copies this integer array's values and returns them in the form of a Vector4Int list.
		///     <br>If 'setCapacity' is set to true, the resulting Vector4Int list will have an automatically determined capacity.</br>
		///     <para>For the conversion to work, the length of this integer array must be a multiple of 4.</para>
		/// </summary>
		public static List<Vector4Int> ToVector4IntList(this int[] arr, bool setCapacity)
		{
			if (arr.Length % 4 != 0)
				throw new ArgumentException("The length of this integer array must be a multiple of 4 when converting to a Vector4Int list.", nameof(arr));

			int numVectors = arr.Length / 4;
			List<Vector4Int> vectorList;
			if (setCapacity)
				vectorList = new List<Vector4Int>(numVectors);
			else
				vectorList = new List<Vector4Int>();

			for (int i = 0; i < numVectors; i++)
			{
				int startIndex = i * 4;
				vectorList.Add(new Vector4Int(arr[startIndex], arr[startIndex + 1], arr[startIndex + 2], arr[startIndex + 3]));
			}

			return vectorList;
		}
		/// <summary>
		///     Copies this integer array's values and returns them in the form of a Vector4Int list with the given capacity.
		///     <para>For the conversion to work, the length of this integer array must be a multiple of 4 and the capacity must not be less than the array's length.</para>
		/// </summary>
		public static List<Vector4Int> ToVector4IntList(this int[] arr, int capacity)
		{
			if (arr.Length % 4 != 0)
				throw new ArgumentException("The length of this integer array must be a multiple of 4 when converting to a Vector4Int list.", nameof(arr));
			else if (capacity < arr.Length)
				throw new ArgumentException("The list capacity must be greater than or equal to the length of this integer array.", nameof(capacity));

			int numVectors = arr.Length / 4;
			List<Vector4Int> vectorList = new List<Vector4Int>(capacity);

			for (int i = 0; i < numVectors; i++)
			{
				int startIndex = i * 4;
				vectorList.Add(new Vector4Int(arr[startIndex], arr[startIndex + 1], arr[startIndex + 2], arr[startIndex + 3]));
			}

			return vectorList;
		}

		// To 'int'
		/// <summary>
		///     Copies this Vector4Int list's component values and returns them in the form of an integer array.
		/// </summary>
		public static int[] ToIntArray(this List<Vector4Int> lst)
		{
			int count = lst.Count;
			int[] intArray = new int[count * 4];

			for (int i = 0; i < count; i++)
			{
				int startIndex = i * 4;
				Vector4Int vector = lst[i];
				intArray[startIndex] = vector.x;
				intArray[startIndex + 1] = vector.y;
				intArray[startIndex + 2] = vector.z;
				intArray[startIndex + 3] = vector.w;
			}

			return intArray;
		}

		/// <summary>
		///     Copies this Vector4Int array's component values and returns them in the form of an integer list.
		/// </summary>
		public static List<int> ToIntList(this Vector4Int[] arr)
		{
			int count = arr.Length;
			List<int> intList = new List<int>();

			for (int i = 0; i < count; i++)
			{
				Vector4Int vector = arr[i];
				intList.Add(vector.x);
				intList.Add(vector.y);
				intList.Add(vector.z);
				intList.Add(vector.w);
			}

			return intList;
		}
		/// <summary>
		///     Copies this Vector4Int array's component values and returns them in the form of an integer list.
		///     <br>If 'setCapacity' is set to true, the resulting integer list will have an automatically determined capacity.</br>
		/// </summary>
		public static List<int> ToIntList(this Vector4Int[] arr, bool setCapacity)
		{
			int count = arr.Length;
			List<int> intList;
			if (setCapacity)
				intList = new List<int>(count * 4);
			else
				intList = new List<int>();

			for (int i = 0; i < count; i++)
			{
				Vector4Int vector = arr[i];
				intList.Add(vector.x);
				intList.Add(vector.y);
				intList.Add(vector.z);
				intList.Add(vector.w);
			}

			return intList;
		}
		/// <summary>
		///     Copies this Vector4Int array's component values and returns them in the form of an integer list with the given capacity.
		///     <para>For the conversion to work, the capacity must not be less than the array's length multiplied by 4.</para>
		/// </summary>
		public static List<int> ToIntList(this Vector4Int[] arr, int capacity)
		{
			if (capacity < arr.Length * 4)
				throw new ArgumentException("The list capacity must be greater than or equal to the length of this Vector4Int array multiplied by 4.", nameof(capacity));

			int count = arr.Length;
			List<int> intList = new List<int>(capacity);

			for (int i = 0; i < count; i++)
			{
				Vector4Int vector = arr[i];
				intList.Add(vector.x);
				intList.Add(vector.y);
				intList.Add(vector.z);
				intList.Add(vector.w);
			}

			return intList;
		}
	}
}

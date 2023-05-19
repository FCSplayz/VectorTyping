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
		public static Vector4Int ToVector4Int(this int[] a)
		{
			if (a.Length == 4)
				return new Vector4Int(a[0], a[1], a[2], a[3]);
			else
				throw new ArgumentException("The length of this integer array must be equal to 4 when converting to Vector4Int.");
		}
	}
}

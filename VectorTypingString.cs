// This code is licensed under the VectorTyping Library License.
///
///  | MIT License
///  | 
///  | Copyright (c) 2023-2024 FCSplayz and Unity Technologies
///  | 
///  | Permission is hereby granted, free of charge, to any person obtaining a copy
///  | of this library and associated documentation files (the "Library"), to deal
///  | in the Library or any derivative works thereof with the following conditions
///
// Refer to the accompanying 'LICENSE.md' file for more information.

#region Assembly VectorTyping, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
#endregion

using System.Globalization;

namespace VectorTyping
{
	internal sealed class VectorTypingString
	{
		public static string Format(string fmt, params object[] args)
		{
			return string.Format(CultureInfo.InvariantCulture.NumberFormat, fmt, args);
		}
	}
}

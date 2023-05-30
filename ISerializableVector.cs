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
using System.Runtime.Serialization;

namespace VectorTyping.Interfaces.Generic
{
	/// <summary>
	///     Interface for serializable vector types.
	/// </summary>
	/// <typeparam name="T">The value type of the vector.</typeparam>
	/// <typeparam name="V">The associated vector type.</typeparam>
	public interface ISerializableVector<T, V> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable where V : struct, ISerializable, IVector<T>
	{
        byte[] Serialize();
        V Deserialize(byte[] data);
    }
}

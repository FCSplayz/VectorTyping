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

namespace VectorTyping.Interfaces.Generic
{
    /// <summary>
    ///     Interface for serializable VectorInt types.
    /// </summary>
    /// <typeparam name="T">The associated VectorInt type.</typeparam>
    public interface ISerializableVectorInt<T> where T : struct, IVector<int>
    {
        byte[] Serialize();
        T Deserialize(byte[] data);
    }
}

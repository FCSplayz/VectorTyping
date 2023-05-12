#region #info || License Information || #endinfo
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
#endregion

#region Assembly VectorTyping, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
#endregion

using System;
using System.Globalization;
using UnityEngine;

namespace VectorTyping
{
	/// <summary>
	///     Representation of 4D vectors and points using integers.
	/// </summary>
	public struct Vector4Int : IEquatable<Vector4Int>, IFormattable
	{
		private int m_X;

		private int m_Y;

		private int m_Z;

		private int m_W;

		private static Vector4Int m_Origin;

		private static readonly Vector4Int s_Zero = new Vector4Int(0, 0, 0, 0);

		private static readonly Vector4Int s_One = new Vector4Int(1, 1, 1, 1);

		private static readonly Vector4Int s_Up = new Vector4Int(0, 1, 0, 0);

		private static readonly Vector4Int s_Down = new Vector4Int(0, -1, 0, 0);

		private static readonly Vector4Int s_Left = new Vector4Int(-1, 0, 0, 0);

		private static readonly Vector4Int s_Right = new Vector4Int(1, 0, 0, 0);

		private static readonly Vector4Int s_Forward = new Vector4Int(0, 0, 1, 0);

		private static readonly Vector4Int s_Back = new Vector4Int(0, 0, -1, 0);

		private static readonly Vector4Int s_Outward = new Vector4Int(0, 0, 0, -1);

		private static readonly Vector4Int s_Inward = new Vector4Int(0, 0, 0, 1);

		/// <summary>
		///    X component of the vector.
		/// </summary>
		public int x
		{
			get
			{
				return m_X;
			}
			set
			{
				m_X = value;
			}
		}

		/// <summary>
		///    Y component of the vector.
		/// </summary>
		public int y
		{
			get
			{
				return m_Y;
			}
			set
			{
				m_Y = value;
			}
		}

		/// <summary>
		///    Z component of the vector.
		/// </summary>
		public int z
		{
			get
			{
				return m_Z;
			}
			set
			{
				m_Z = value;
			}
		}

		/// <summary>
		///    W component of the vector.
		/// </summary>
		public int w
		{
			get
			{
				return m_W;
			}
			set
			{
				m_W = value;
			}
		}

		public int this[int index]
		{
			get
			{
				return index switch
				{
					0 => x,
					1 => y,
					2 => z,
					3 => w,
					_ => throw new IndexOutOfRangeException(VectorTypingString.Format("Invalid Vector4Int index addressed: {0}!", index)),
				};
			}
			set
			{
				switch (index)
				{
					case 0:
						x = value;
						break;
					case 1:
						y = value;
						break;
					case 2:
						z = value;
						break;
					case 3:
						w = value;
						break;
					default:
						throw new IndexOutOfRangeException(VectorTypingString.Format("Invalid Vector4Int index addressed: {0}!", index));
				}
			}
		}
		
		/// <summary>
		///     Returns a copy of this vector's origin point (Read Only).
		/// </summary>
		public Vector4Int origin => m_Origin;

		/// <summary>
		///     Returns a copy of this vector with a magnitude of 1 (Read Only).
		/// </summary>
		public Vector4Int normalized => Normalize(this);

		/// <summary>
		///     Returns the magnitude of this vector (Read Only).
		/// </summary>
		public double magnitude => Magnitude(this);

		/// <summary>
		///     Returns the square magnitude of this vector (Read Only).
		/// </summary>
		public double sqrMagnitude => SqrMagnitude(this);

		/// <summary>
		///     Returns the cube magnitude of this vector (Read Only).
		/// </summary>
		public double cbMagnitude => CbMagnitude(this);

		/// <summary>
		///     Returns the exponentiated magnitude of this vector (Read Only).
		/// </summary>
		public double expMagnitude => ExpMagnitude(this);

		/// <summary>
		///     Returns the exponentiated sqaure magnitude of this vector (Read Only).
		/// </summary>
		public double expSqrMagnitude => ExpSqrMagnitude(this);

		/// <summary>
		///     Returns the exponentiated cube magnitude of this vector (Read Only).
		/// </summary>
		public double expCbMagnitude => ExpCbMagnitude(this);

		/// <summary>
		///     Shorthand for writing Vector4Int(0, 0, 0, 0).
		/// </summary>
		public static Vector4Int zero => s_Zero;

		/// <summary>
		///     Shorthand for writing Vector4Int(1, 1, 1, 1).
		/// </summary>
		public static Vector4Int one => s_One;

		/// <summary>
		///     Shorthand for writing Vector4Int(0, 1, 0, 0).
		/// </summary>
		public static Vector4Int up => s_Up;

		/// <summary>
		///     Shorthand for writing Vector4Int(0, -1, 0, 0).
		/// </summary>
		public static Vector4Int down => s_Down;

		/// <summary>
		///     Shorthand for writing Vector4Int(-1, 0, 0, 0).
		/// </summary>
		public static Vector4Int left => s_Left;

		/// <summary>
		///     Shorthand for writing Vector4Int(1, 0, 0, 0).
		/// </summary>
		public static Vector4Int right => s_Right;

		/// <summary>
		///     Shorthand for writing Vector4Int(0, 0, 1, 0).
		/// </summary>
		public static Vector4Int forward => s_Forward;

		/// <summary>
		///     Shorthand for writing Vector4Int(0, 0, -1, 0).
		/// </summary>
		public static Vector4Int back => s_Back;

		/// <summary>
		///     Shorthand for writing Vector4Int(0, 0, 0, -1).
		/// </summary>
		public static Vector4Int outward => s_Outward;

		/// <summary>
		///     Shorthand for writing Vector4Int(0, 0, 0, 1).
		/// </summary>
		public static Vector4Int inward => s_Inward;

		// Constructors
		/// <summary>
		///     Constructs a new Vector4Int.
		/// </summary>
		public Vector4Int(int x, int y, int z, int w)
		{
			this.m_X = x;
			this.m_Y = y;
			this.m_Z = z;
			this.m_W = w;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int and sets w to zero.
		/// </summary>
		public Vector4Int(int x, int y, int z)
		{
			this.m_X = x;
			this.m_Y = y;
			this.m_Z = z;
			this.m_W = 0;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int and sets z, w to zero.
		/// </summary>
		public Vector4Int(int x, int y)
		{
			this.m_X = x;
			this.m_Y = y;
			this.m_Z = 0;
			this.m_W = 0;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int and sets y, z and w to zero.
		/// </summary>
		public Vector4Int(int x)
		{
			this.m_X = x;
			this.m_Y = 0;
			this.m_Z = 0;
			this.m_W = 0;
			m_Origin = this;
		}

		/// <summary>
		///     Constructs a new Vector4Int from a Vector3Int with the given w component.
		/// </summary>
		public Vector4Int(Vector3Int v, int w)
		{
			this.m_X = v.x;
			this.m_Y = v.y;
			this.m_Z = v.z;
			this.m_W = w;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int from a Vector3Int and sets w to zero.
		/// </summary>
		public Vector4Int(Vector3Int v)
		{
			this.m_X = v.x;
			this.m_Y = v.y;
			this.m_Z = v.z;
			this.m_W = 0;
			m_Origin = this;
		}

		/// <summary>
		///     Constructs a new Vector4Int from two Vector2Ints.
		/// </summary>
		public Vector4Int(Vector2Int a, Vector2Int b)
		{
			this.m_X = a.x;
			this.m_Y = a.y;
			this.m_Z = b.x;
			this.m_W = b.y;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int from a Vector2Int with the given z, w components.
		/// </summary>
		public Vector4Int(Vector2Int v, int z, int w)
		{
			this.m_X = v.x;
			this.m_Y = v.y;
			this.m_Z = z;
			this.m_W = w;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int from a Vector2Int with the given z component and sets w to zero.
		/// </summary>
		public Vector4Int(Vector2Int v, int z)
		{
			this.m_X = v.x;
			this.m_Y = v.y;
			this.m_Z = z;
			this.m_W = 0;
			m_Origin = this;
		}
		/// <summary>
		///     Constructs a new Vector4Int from a Vector2Int and sets z, w to zero.
		/// </summary>
		public Vector4Int(Vector2Int v)
		{
			this.m_X = v.x;
			this.m_Y = v.y;
			this.m_Z = 0;
			this.m_W = 0;
			m_Origin = this;
		}

		// Conversion operators
		public static implicit operator Vector4Int(Vector4 v)
		{
			return new Vector4Int((int)v.x, (int)v.y, (int)v.z, (int)v.w);
		}

		public static implicit operator Vector4(Vector4Int v)
		{
			return new Vector4(v.x, v.y, v.z, v.w);
		}

		public static explicit operator Vector4Int(Vector3Int v)
		{
			return new Vector4Int(v.x, v.y, v.z, 0);
		}

		public static explicit operator Vector3Int(Vector4Int v)
		{
			return new Vector3Int(v.x, v.y, v.z);
		}

		public static explicit operator Vector4Int(Vector2Int v)
		{
			return new Vector4Int(v.x, v.y, 0, 0);
		}

		public static explicit operator Vector2Int(Vector4Int v)
		{
			return new Vector2Int(v.x, v.y);
		}

		public static explicit operator Vector4Int(Color32 c)
		{
			return new Vector4Int(c.r, c.g, c.b, c.a);
		}

		public static explicit operator Color32(Vector4Int v)
		{
			return new Color32((byte)v.x, (byte)v.y, (byte)v.z, (byte)v.w);
		}

		// Math operators
		public static Vector4Int operator +(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}
		public static Vector4Int operator +(Vector4Int a, int b)
		{
			return new Vector4Int(a.x + b, a.y + b, a.z + b, a.w + b);
		}

		public static Vector4Int operator +(Vector4Int v)
		{
			return new Vector4Int(+v.x, +v.y, +v.z, +v.w);
		}

		public static Vector4Int operator ++(Vector4Int v)
		{
			v.x++;
			v.y++;
			v.z++;
			v.w++;
			return v;
		}

		public static Vector4Int operator -(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}
		public static Vector4Int operator -(Vector4Int a, int b)
		{
			return new Vector4Int(a.x - b, a.y - b, a.z - b, a.w - b);
		}

		public static Vector4Int operator -(Vector4Int v)
		{
			return new Vector4Int(-v.x, -v.y, -v.z, -v.w);
		}

		public static Vector4Int operator --(Vector4Int v)
		{
			v.x--;
			v.y--;
			v.z--;
			v.w--;
			return v;
		}

		public static Vector4Int operator *(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}
		public static Vector4Int operator *(Vector4Int a, int b)
		{
			return new Vector4Int(a.x * b, a.y * b, a.z * b, a.w * b);
		}
		public static Vector4Int operator *(int a, Vector4Int b)
		{
			return new Vector4Int(a * b.x, a * b.y, a * b.z, a * b.w);
		}
		public static Vector4Int operator *(Vector4Int a, float b)
		{
			return new Vector4Int((int)(a.x * b), (int)(a.y * b), (int)(a.z * b), (int)(a.w * b));
		}
		public static Vector4Int operator *(float a, Vector4Int b)
		{
			return new Vector4Int((int)(a * b.x), (int)(a * b.y), (int)(a * b.z), (int)(a * b.w));
		}
		public static Vector4Int operator *(Vector4Int a, double b)
		{
			return new Vector4Int((int)(a.x * b), (int)(a.y * b), (int)(a.z * b), (int)(a.w * b));
		}
		public static Vector4Int operator *(double a, Vector4Int b)
		{
			return new Vector4Int((int)(a * b.x), (int)(a * b.y), (int)(a * b.z), (int)(a * b.w));
		}

		public static Vector4Int operator /(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		}
		public static Vector4Int operator /(Vector4Int a, int b)
		{
			return new Vector4Int(a.x / b, a.y / b, a.z / b, a.w / b);
		}
		public static Vector4Int operator /(Vector4Int a, float b)
		{
			return new Vector4Int((int)(a.x / b), (int)(a.y / b), (int)(a.z / b), (int)(a.w / b));
		}
		public static Vector4Int operator /(Vector4Int a, double b)
		{
			return new Vector4Int((int)(a.x / b), (int)(a.y / b), (int)(a.z / b), (int)(a.w / b));
		}

		public static Vector4Int operator %(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w);
		}
		public static Vector4Int operator %(Vector4Int a, int b)
		{
			return new Vector4Int(a.x % b, a.y % b, a.z % b, a.w % b);
		}
		public static Vector4Int operator %(Vector4Int a, float b)
		{
			return new Vector4Int((int)(a.x % b), (int)(a.y % b), (int)(a.z % b), (int)(a.w % b));
		}
		public static Vector4Int operator %(Vector4Int a, double b)
		{
			return new Vector4Int((int)(a.x % b), (int)(a.y % b), (int)(a.z % b), (int)(a.w % b));
		}

		// Conditional operators
		public static bool operator ==(Vector4Int lhs, Vector4Int rhs)
		{
			return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w;
		}
		public static bool operator ==(Vector4Int lhs, Vector4 rhs)
		{
			return Mathf.Approximately(lhs.x, rhs.x) && Mathf.Approximately(lhs.y, rhs.y)
				&& Mathf.Approximately(lhs.z, rhs.z) && Mathf.Approximately(lhs.w, rhs.w);
		}
		public static bool operator ==(Vector4 lhs, Vector4Int rhs)
		{
			return Mathf.Approximately(lhs.x, rhs.x) && Mathf.Approximately(lhs.y, rhs.y)
				&& Mathf.Approximately(lhs.z, rhs.z) && Mathf.Approximately(lhs.w, rhs.w);
		}
		/// <summary>
		///     Extended form of the !!Vector4Int operation which allows checking for any number instead of just 0.
		///     <br>However, for readability, if checking for a value of 0, using the !!Vector4Int operation is recommended instead.</br>
		///     <para>Returns a vector containing 1s and 0s based on if a component of 'lhs' had the value of 'rhs' or not.</para>
		/// </summary>
		public static Vector4Int operator ==(Vector4Int lhs, int rhs)
		{
			return new Vector4Int(lhs.x == rhs ? 1 : 0, lhs.y == rhs ? 1 : 0, lhs.z == rhs ? 1 : 0, lhs.w == rhs ? 1 : 0);
		}
		/// <summary>
		///     Extended form of the !!Vector4Int operation which allows checking for any number instead of just 0 for each individual component.
		///     <br>However, for readability, if checking all for a value of 0, using the !!Vector4Int operation is recommended instead.</br>
		///     <para>Returns a vector containing 1s and 0s based on if a component of 'lhs' had the value of 'rhs' for said component or not.</para>
		/// </summary>
		public static Vector4Int operator ==(Vector4Int lhs, (int x, int y, int z, int w) rhs)
		{
			return new Vector4Int(lhs.x == rhs.x ? 1 : 0, lhs.y == rhs.y ? 1 : 0, lhs.z == rhs.z ? 1 : 0, lhs.w == rhs.w ? 1 : 0);
		}

		public static bool operator !=(Vector4Int lhs, Vector4Int rhs)
		{
			return lhs.x != rhs.x && lhs.y != rhs.y && lhs.z != rhs.z && lhs.w != rhs.w;
		}
		public static bool operator !=(Vector4Int lhs, Vector4 rhs)
		{
			return !Mathf.Approximately(lhs.x, rhs.x) && !Mathf.Approximately(lhs.y, rhs.y)
				&& !Mathf.Approximately(lhs.z, rhs.z) && !Mathf.Approximately(lhs.w, rhs.w);
		}
		public static bool operator !=(Vector4 lhs, Vector4Int rhs)
		{
			return !Mathf.Approximately(lhs.x, rhs.x) && !Mathf.Approximately(lhs.y, rhs.y)
				&& !Mathf.Approximately(lhs.z, rhs.z) && !Mathf.Approximately(lhs.w, rhs.w);
		}
		/// <summary>
		///     Extended form of the !Vector4Int operation which allows checking for any number instead of just 0.
		///     <br>However, for readability, if checking for a value of 0, using the !Vector4Int operation is recommended instead.</br>
		///     <para>Returns a vector containing 0s and 1s based on if a component of 'lhs' had the value of 'rhs' or not.</para>
		/// </summary>
		public static Vector4Int operator !=(Vector4Int lhs, int rhs)
		{
			return new Vector4Int(lhs.x != rhs ? 1 : 0, lhs.y != rhs ? 1 : 0, lhs.z != rhs ? 1 : 0, lhs.w != rhs ? 1 : 0);
		}
		/// <summary>
		///     Extended form of the !!Vector4Int operation which allows checking for any number instead of just 0 for each individual component.
		///     <br>However, for readability, if checking all for a value of 0, using the !!Vector4Int operation is recommended instead.</br>
		///     <para>Returns a vector containing 1s and 0s based on if a component of 'lhs' had the value of 'rhs' for said component or not.</para>
		/// </summary>
		public static Vector4Int operator !=(Vector4Int lhs, (int x, int y, int z, int w) rhs)
		{
			return new Vector4Int(lhs.x != rhs.x ? 1 : 0, lhs.y != rhs.y ? 1 : 0, lhs.z != rhs.z ? 1 : 0, lhs.w != rhs.w ? 1 : 0);
		}

		public static bool operator >(Vector4Int lhs, Vector4Int rhs)
		{
			return lhs.x > rhs.x && lhs.y > rhs.y && lhs.z > rhs.z && lhs.w > rhs.w;
		}

		public static bool operator <(Vector4Int lhs, Vector4Int rhs)
		{
			return lhs.x < rhs.x && lhs.y < rhs.y && lhs.z < rhs.z && lhs.w < rhs.w;
		}

		public static bool operator >=(Vector4Int lhs, Vector4Int rhs)
		{
			return lhs.x >= rhs.x && lhs.y >= rhs.y && lhs.z >= rhs.z && lhs.w >= rhs.w;
		}

		public static bool operator <=(Vector4Int lhs, Vector4Int rhs)
		{
			return lhs.x <= rhs.x && lhs.y <= rhs.y && lhs.z <= rhs.z && lhs.w <= rhs.w;
		}

		// Logical operators
		public static Vector4Int operator &(Vector4Int lhs, Vector4Int rhs)
		{
			return new Vector4Int(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
		}

		public static Vector4Int operator |(Vector4Int lhs, Vector4Int rhs)
		{
			return new Vector4Int(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
		}

		public static Vector4Int operator ^(Vector4Int lhs, Vector4Int rhs)
		{
			return new Vector4Int(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
		}

		public static Vector4Int operator ~(Vector4Int v)
		{
			return new Vector4Int(~v.x, ~v.y, ~v.z, ~v.w);
		}

		public static Vector4Int operator <<(Vector4Int v, int shiftl)
		{
			return new Vector4Int(v.x << shiftl, v.y << shiftl, v.z << shiftl, v.w << shiftl);
		}

		public static Vector4Int operator >>(Vector4Int v, int shiftr)
		{
			return new Vector4Int(v.x >> shiftr, v.y >> shiftr, v.z >> shiftr, v.w >> shiftr);
		}

		/// <summary>
		///     Returns a vector containing 1s and 0s depending on if a component of 'v' was a zero or non-zero value.
		/// </summary>
		public static Vector4Int operator !(Vector4Int v)
		{
			return new Vector4Int(v.x == 0 ? 1 : 0, v.y == 0 ? 1 : 0, v.z == 0 ? 1 : 0, v.w == 0 ? 1 : 0);
		}

		// Additional operators
		/// <summary>
		///     Sets the x, y, z and w components of this vector.
		/// </summary>
		public void Set(int x, int y, int z, int w)
		{
			m_X = x;
			m_Y = y;
			m_Z = z;
			m_W = w;
		}
		/// <summary>
		///     Copies the x, y, z and w components from an existing vector over to this vector.
		/// </summary>
		public Vector4Int Copy(Vector4Int v)
		{
			m_X = v.x;
			m_Y = v.y;
			m_Z = v.z;
			m_W = v.w;
			return new Vector4Int(v.x, v.y, v.z, v.w);
		}

		/// <summary>
		///     Resets the x, y, z and w components of this vector back to their origin point.
		/// </summary>
		public Vector4Int Reset()
		{
			this = m_Origin;
			return m_Origin;
		}

		/// <summary>
		///     Sets the origin point of this vector.
		/// </summary>
		public Vector4Int SetOriginHere()
		{
			m_Origin = this;
			return m_Origin;
		}

		/// <summary>
		///     Sets the origin point of this vector.
		/// </summary>
		public Vector4Int SetOriginAt(int x, int y, int z, int w)
		{
			m_Origin.m_X = x;
			m_Origin.m_Y = y;
			m_Origin.m_Z = z;
			m_Origin.m_W = w;
			return m_Origin;
		}

		/// <summary>
		///     Returns the absolute vector of the given vector.
		/// </summary>
		public static Vector4Int Abs(Vector4Int v)
		{
			int ax = v.x < 0 ? -v.x : v.x;
			int ay = v.y < 0 ? -v.y : v.y;
			int az = v.z < 0 ? -v.z : v.z;
			int aw = v.w < 0 ? -v.w : v.w;
			return new Vector4Int(ax, ay, az, aw);
		}
		/// <summary>
		///     Converts this vector into its absolute vector.
		/// </summary>
		public Vector4Int Abs()
		{
			int ax = x < 0 ? -x : x;
			int ay = y < 0 ? -y : y;
			int az = z < 0 ? -z : z;
			int aw = w < 0 ? -w : w;
			x = ax;
			y = ay;
			z = az;
			w = aw;
			return new Vector4Int(ax, ay, az, aw);
		}

		/// <summary>
		///     Converts the given Vector4 to a Vector4Int by doing a Floor to each value.
		/// </summary>
		public static Vector4Int FloorToInt(Vector4 v)
		{
			return new Vector4Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z), Mathf.FloorToInt(v.w));
		}
		/// <summary>
		///     Converts the given Vector4 to a Vector4Int by doing a Ceil to each value.
		/// </summary>
		public static Vector4Int CeilToInt(Vector4 v)
		{
			return new Vector4Int(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y), Mathf.CeilToInt(v.z), Mathf.CeilToInt(v.w));
		}
		/// <summary>
		///     Converts the given Vector4 to a Vector4Int by doing a Round to each value.
		/// </summary>
		public static Vector4Int RoundToInt(Vector4 v)
		{
			return new Vector4Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z), Mathf.RoundToInt(v.w));
		}

		/// <summary>
		///     Multiplies two vectors component-wise and returns the result.
		/// </summary>
		public static Vector4Int Upscale(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}
		/// <summary>
		///     Multiplies every component of this vector by the same component of scale.
		/// </summary>
		public void Upscale(Vector4Int scale)
		{
			x *= scale.x;
			y *= scale.y;
			z *= scale.z;
			w *= scale.w;
		}

		/// <summary>
		///     Divides two vectors component-wise and returns the result.
		/// </summary>
		public static Vector4Int Downscale(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		}
		/// <summary>
		///     Divides every component of this vector by the same component of scale.
		/// </summary>
		public void Downscale(Vector4Int scale)
		{
			x /= scale.x;
			y /= scale.y;
			z /= scale.z;
			w /= scale.w;
		}

		/// <summary>
		///     Exponentiates two vectors component-wise and returns the result.
		/// </summary>
		public static Vector4Int Pow(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int((int)Math.Pow(a.x, b.x), (int)Math.Pow(a.y, b.y), (int)Math.Pow(a.z, b.z), (int)Math.Pow(a.w, b.w));
		}
		/// <summary>
		///     Exponentiates every component of this vector by the same component of 'power'.
		/// </summary>
		public Vector4Int Pow(Vector4Int power)
		{
			int ex = (int)Math.Pow(x, power.x);
			int ey = (int)Math.Pow(y, power.y);
			int ez = (int)Math.Pow(z, power.z);
			int ew = (int)Math.Pow(w, power.w);
			x = ex;
			y = ey;
			z = ez;
			w = ew;
			return new Vector4Int(ex, ey, ez, ew);
		}
		/// <summary>
		///     Returns a vector with every component of the given vector exponentiated by the given integer 'b'.
		/// </summary>
		public static Vector4Int Pow(Vector4Int a, int b)
		{
			return new Vector4Int((int)Math.Pow(a.x, b), (int)Math.Pow(a.y, b), (int)Math.Pow(a.z, b), (int)Math.Pow(a.w, b));
		}
		/// <summary>
		///     Exponentiates every component of this vector by the given integer of 'power'.
		/// </summary>
		public Vector4Int Pow(int power)
		{
			int ex = (int)Math.Pow(x, power);
			int ey = (int)Math.Pow(y, power);
			int ez = (int)Math.Pow(z, power);
			int ew = (int)Math.Pow(w, power);
			x = ex;
			y = ey;
			z = ez;
			w = ew;
			return new Vector4Int(ex, ey, ez, ew);
		}
		/// <summary>
		///     Returns a vector with every component of the given vector exponentiated by the given floating-point 'b'.
		/// </summary>
		public static Vector4Int Pow(Vector4Int a, float b)
		{
			return new Vector4Int((int)Math.Pow(a.x, b), (int)Math.Pow(a.y, b), (int)Math.Pow(a.z, b), (int)Math.Pow(a.w, b));
		}
		/// <summary>
		///     Exponentiates every component of this vector by the given floating-point of 'power'.
		/// </summary>
		public Vector4Int Pow(float power)
		{
			int ex = (int)Math.Pow(x, power);
			int ey = (int)Math.Pow(y, power);
			int ez = (int)Math.Pow(z, power);
			int ew = (int)Math.Pow(w, power);
			x = ex;
			y = ey;
			z = ez;
			w = ew;
			return new Vector4Int(ex, ey, ez, ew);
		}
		/// <summary>
		///     Returns a vector with every component of the given vector exponentiated by the given double 'b'.
		/// </summary>
		public static Vector4Int Pow(Vector4Int a, double b)
		{
			return new Vector4Int((int)Math.Pow(a.x, b), (int)Math.Pow(a.y, b), (int)Math.Pow(a.z, b), (int)Math.Pow(a.w, b));
		}
		/// <summary>
		///     Exponentiates every component of this vector by the given double of 'power'.
		/// </summary>
		public Vector4Int Pow(double power)
		{
			int ex = (int)Math.Pow(x, power);
			int ey = (int)Math.Pow(y, power);
			int ez = (int)Math.Pow(z, power);
			int ew = (int)Math.Pow(w, power);
			x = ex;
			y = ey;
			z = ez;
			w = ew;
			return new Vector4Int(ex, ey, ez, ew);
		}

		/// <summary>
		///     Returns a vector with the square root of every component of the given vector.
		/// </summary>
		public static Vector4Int Sqrt(Vector4Int a)
		{
			return new Vector4Int((int)Math.Sqrt(a.x),
								  (int)Math.Sqrt(a.y),
								  (int)Math.Sqrt(a.z),
								  (int)Math.Sqrt(a.w)
			);
		}
		/// <summary>
		///     Square roots every component of this vector.
		/// </summary>
		public Vector4Int Sqrt()
		{
			int rx = (int)Math.Sqrt(x);
			int ry = (int)Math.Sqrt(y);
			int rz = (int)Math.Sqrt(z);
			int rw = (int)Math.Sqrt(w);
			x = rx;
			y = ry;
			z = rz;
			w = rw;
			return new Vector4Int(rx, ry, rz, rw);
		}

		/// <summary>
		///     Returns a vector with the cube root of every component of the given vector.
		/// </summary>
		public static Vector4Int Cbrt(Vector4Int v)
		{
			int rx = Math.Sign(v.x) * (int)Math.Pow(Math.Abs(v.x), 1.0 / 3.0);
			int ry = Math.Sign(v.y) * (int)Math.Pow(Math.Abs(v.y), 1.0 / 3.0);
			int rz = Math.Sign(v.z) * (int)Math.Pow(Math.Abs(v.z), 1.0 / 3.0);
			int rw = Math.Sign(v.w) * (int)Math.Pow(Math.Abs(v.w), 1.0 / 3.0);
			return new Vector4Int(rx, ry, rz, rw);
		}
		/// <summary>
		///     Cube roots every component of this vector.
		/// </summary>
		public Vector4Int Cbrt()
		{
			int rx = Math.Sign(x) * (int)Math.Pow(Math.Abs(x), 1.0 / 3.0);
			int ry = Math.Sign(y) * (int)Math.Pow(Math.Abs(y), 1.0 / 3.0);
			int rz = Math.Sign(z) * (int)Math.Pow(Math.Abs(z), 1.0 / 3.0);
			int rw = Math.Sign(w) * (int)Math.Pow(Math.Abs(w), 1.0 / 3.0);
			x = rx;
			y = ry;
			z = rz;
			w = rw;
			return new Vector4Int(rx, ry, rz, rw);
		}

		/// <summary>
		///     Returns a vector with the given integer root index 'b' of every component of the given vector.
		///     <br>If using a root index of 2, it is recommended to use Sqrt(Vector4Int) instead.</br>
		/// </summary>
		public static Vector4Int Root(Vector4Int a, int b)
		{
			return new Vector4Int((int)Math.Pow(a.x, 1.0 / b),
								  (int)Math.Pow(a.y, 1.0 / b),
								  (int)Math.Pow(a.z, 1.0 / b),
								  (int)Math.Pow(a.w, 1.0 / b)
			);
		}
		/// <summary>
		///     Roots every component of this vector by the given integer root index 'n'.
		///     <br>If using a root index of 2, it is recommended to use Vector4Int.Sqrt instead.</br>
		/// </summary>
		public Vector4Int Root(int n)
		{
			int rx = (int)Math.Pow(x, 1.0 / n);
			int ry = (int)Math.Pow(y, 1.0 / n);
			int rz = (int)Math.Pow(z, 1.0 / n);
			int rw = (int)Math.Pow(w, 1.0 / n);
			x = rx;
			y = ry;
			z = rz;
			w = rw;
			return new Vector4Int(rx, ry, rz, rw);
		}
		/// <summary>
		///     Roots every component of this vector by the given floating-point root index 'b'.
		///     <br>If using a root index of 2f, it is recommended to use Sqrt(Vector4Int) instead.</br>
		/// </summary>
		public static Vector4Int Root(Vector4Int a, float b)
		{
			return new Vector4Int((int)Math.Pow(a.x, 1.0 / b),
								  (int)Math.Pow(a.y, 1.0 / b),
								  (int)Math.Pow(a.z, 1.0 / b),
								  (int)Math.Pow(a.w, 1.0 / b)
			);
		}
		/// <summary>
		///     Roots every component of this vector by the given floating-point root index 'n'.
		///     <br>If using a root index of 2f, it is recommended to use Vector4Int.Sqrt instead.</br>
		/// </summary>
		public Vector4Int Root(float n)
		{
			int rx = (int)Math.Pow(x, 1.0 / n);
			int ry = (int)Math.Pow(y, 1.0 / n);
			int rz = (int)Math.Pow(z, 1.0 / n);
			int rw = (int)Math.Pow(w, 1.0 / n);
			x = rx;
			y = ry;
			z = rz;
			w = rw;
			return new Vector4Int(rx, ry, rz, rw);
		}
		/// <summary>
		///     Returns a vector with the given double root index 'b' of every component of the given vector.
		///     <br>If using a root index of 2.0, it is recommended to use Sqrt(Vector4Int) instead.</br>
		/// </summary>
		public static Vector4Int Root(Vector4Int a, double b)
		{
			return new Vector4Int((int)Math.Pow(a.x, 1.0 / b),
								  (int)Math.Pow(a.y, 1.0 / b),
								  (int)Math.Pow(a.z, 1.0 / b),
								  (int)Math.Pow(a.w, 1.0 / b)
			);
		}
		/// <summary>
		///     Roots every component of this vector by the given double root index 'n'.
		///     <br>If using a root index of 2.0, it is recommended to use Vector4Int.Sqrt instead.</br>
		/// </summary>
		public Vector4Int Root(double n)
		{
			int rx = (int)Math.Pow(x, 1.0 / n);
			int ry = (int)Math.Pow(y, 1.0 / n);
			int rz = (int)Math.Pow(z, 1.0 / n);
			int rw = (int)Math.Pow(w, 1.0 / n);
			x = rx;
			y = ry;
			z = rz;
			w = rw;
			return new Vector4Int(rx, ry, rz, rw);
		}

		/// <summary>
		///     Returns the logarithm of the given vector in the specified base.
		/// </summary>
		public static Vector4Int Log(Vector4Int v, int baseValue)
		{
			return new Vector4Int(
				(int)Math.Log(v.x, baseValue),
				(int)Math.Log(v.y, baseValue),
				(int)Math.Log(v.z, baseValue),
				(int)Math.Log(v.w, baseValue)
			);
		}
		/// <summary>
		///     Sets every component in this vector to its logarithm in the specified base.
		/// </summary>
		public Vector4Int Log(int baseValue)
		{
			int lx = (int)Math.Log(x, baseValue);
			int ly = (int)Math.Log(x, baseValue);
			int lz = (int)Math.Log(x, baseValue);
			int lw = (int)Math.Log(x, baseValue);
			x = lx;
			y = ly;
			z = lz;
			w = lw;
			return new Vector4Int(lx, ly, lz, lw);
		}

		/// <summary>
		///     Returns the natural logarithm of the given vector.
		/// </summary>
		public static Vector4Int LogN(Vector4Int v)
		{
			return new Vector4Int(
				(int)Math.Log(v.x),
				(int)Math.Log(v.y),
				(int)Math.Log(v.z),
				(int)Math.Log(v.w)
			);
		}
		/// <summary>
		///     Sets every component in this vector to its natural logarithm.
		/// </summary>
		public Vector4Int LogN()
		{
			int lnx = (int)Math.Log(x);
			int lny = (int)Math.Log(y);
			int lnz = (int)Math.Log(z);
			int lnw = (int)Math.Log(w);
			x = lnx;
			y = lny;
			z = lnz;
			w = lnw;
			return new Vector4Int(lnx, lny, lnz, lnw);
		}

		/// <summary>
		///     Returns the 10-base logarithm of the given vector.
		/// </summary>
		public static Vector4Int Log10(Vector4Int v)
		{
			return new Vector4Int(
				(int)Math.Log10(v.x),
				(int)Math.Log10(v.y),
				(int)Math.Log10(v.z),
				(int)Math.Log10(v.w)
			);
		}
		/// <summary>
		///     Sets every component in this vector to its 10-base logarithm.
		/// </summary>
		public Vector4Int Log10()
		{
			int ltx = (int)Math.Log10(x);
			int lty = (int)Math.Log10(y);
			int ltz = (int)Math.Log10(z);
			int ltw = (int)Math.Log10(w);
			x = ltx;
			y = lty;
			z = ltz;
			w = ltw;
			return new Vector4Int(ltx, lty, ltz, ltw);
		}

		/// <summary>
		///     Returns a vector that is made from the smallest components of the two given vectors.
		/// </summary>
		public static Vector4Int Min(Vector4Int lhs, Vector4Int rhs)
		{
			return new Vector4Int(
				Mathf.Min(lhs.x, rhs.x),
				Mathf.Min(lhs.y, rhs.y),
				Mathf.Min(lhs.z, rhs.z),
				Mathf.Min(lhs.w, rhs.w)
			);
		}

		/// <summary>
		///     Returns a vector that is made from the averages between the components of the two given vectors.
		/// </summary>
		public static Vector4Int Mid(Vector4Int lhs, Vector4Int rhs)
		{
			return new Vector4Int(
				(lhs.x + rhs.x) / 2,
				(lhs.y + rhs.y) / 2,
				(lhs.z + rhs.z) / 2,
				(lhs.w + rhs.w) / 2
			);
		}

		/// <summary>
		///     Returns a vector that is made from the largest components of the two given vectors.
		/// </summary>
		public static Vector4Int Max(Vector4Int lhs, Vector4Int rhs)
		{
			return new Vector4Int(
				Mathf.Max(lhs.x, rhs.x),
				Mathf.Max(lhs.y, rhs.y),
				Mathf.Max(lhs.z, rhs.z),
				Mathf.Max(lhs.w, rhs.w)
			);
		}

		/// <summary>
		///     Returns a vector that is in the center of each component of the given vector, rounded to the nearest integer.
		/// </summary>
		public static Vector4Int Center(Vector4Int v)
		{
			return new Vector4Int(
				(int)Math.Round((double)(v.x / 4)),
				(int)Math.Round((double)(v.y / 4)),
				(int)Math.Round((double)(v.z / 4)),
				(int)Math.Round((double)(v.w / 4))
			);
		}
		/// <summary>
		///     Centers this vector to the point that is in the center of each component, rounded to the nearest integer.
		/// </summary>
		public Vector4Int Center()
		{
			int mcx = (int)Math.Round((double)(x / 4));
			int mcy = (int)Math.Round((double)(y / 4));
			int mcz = (int)Math.Round((double)(z / 4));
			int mcw = (int)Math.Round((double)(w / 4));
			x = mcx;
			y = mcy;
			z = mcz;
			w = mcw;
			return new Vector4Int(mcx, mcy, mcz, mcw);
		}

		/// <summary>
		///     Returns a vector that is in the center of each component of the given vector, mirrored along the specified axes, and rounded to the nearest integer.
		///     <br>If you are not mirroring the center point along any of the axes, it is recommended to use Center(Vector4Int) instead.</br>
		/// </summary>
		public static Vector4Int MirrCenter(Vector4Int v, (bool x, bool y, bool z, bool w) mirroredAxes)
		{
			int mx = mirroredAxes.x ? -1 : 1;
			int my = mirroredAxes.y ? -1 : 1;
			int mz = mirroredAxes.z ? -1 : 1;
			int mw = mirroredAxes.w ? -1 : 1;
			return new Vector4Int(
				mx * (int)Math.Round((double)(v.x / 4)),
				my * (int)Math.Round((double)(v.y / 4)),
				mz * (int)Math.Round((double)(v.z / 4)),
				mw * (int)Math.Round((double)(v.w / 4))
			);
		}
		/// <summary>
		///     Centers this vector to the point that is in the center of each component, mirrored along the specified axes, and rounded to the nearest integer.
		///     <br>If you are not mirroring the center point along any of the axes, it is recommended to use Vector4Int.Center instead.</br>
		/// </summary>
		public Vector4Int MirrCenter((bool x, bool y, bool z, bool w) mirroredAxes)
		{
			int mx = mirroredAxes.x ? -1 : 1;
			int my = mirroredAxes.y ? -1 : 1;
			int mz = mirroredAxes.z ? -1 : 1;
			int mw = mirroredAxes.w ? -1 : 1;
			int mcx = mx * (int)Math.Round((double)(x / 4));
			int mcy = my * (int)Math.Round((double)(y / 4));
			int mcz = mz * (int)Math.Round((double)(z / 4));
			int mcw = mw * (int)Math.Round((double)(w / 4));
			x = mcx;
			y = mcy;
			z = mcz;
			w = mcw;
			return new Vector4Int(mcx, mcy, mcz, mcw);
		}

		/// <summary>
		///     Returns the Dot Product of vectors a and b.
		/// </summary>
		public static int Dot(Vector4Int a, Vector4Int b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
		}

		/// <summary>
		///    Returns the Cross Product of vectors a and b.
		/// </summary>
		public static Vector4Int Cross(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(
				a.y * b.z - a.z * b.y,
				a.z * b.w - a.w * b.z,
				a.w * b.x - a.x * b.w,
				a.x * b.y - a.y * b.x
			);
		}

		/// <summary>
		///    Returns the Sum Product of vectors a and b.
		/// </summary>
		public static Vector4Int Sum(Vector4Int a, Vector4Int b)
		{
			return new Vector4Int(
				a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w,
				a.x * b.y + a.y * b.x + a.z * b.w + a.w * b.z,
				a.x * b.z + a.y * b.w + a.z * b.x + a.w * b.y,
				a.x * b.w + a.y * b.z + a.z * b.y + a.w * b.x
			);
		}

		/// <summary>
		///    Computes the intersection point of three planes defined by three non-collinear points in 4D space.
		///    <para>Returns a vector of zero if the given vectors are collinear or if they all coincide.</para>
		/// </summary>
		public static Vector4Int Triangulate(Vector4Int a, Vector4Int b, Vector4Int c)
		{
			// Check if all points are the same
			if (a == b && b == c)
			{
				// All points are the same, return a default value
				return zero;
			}

			// Check for collinear points
			Vector4Int ab = b - a;
			Vector4Int ac = c - a;
			if (Cross(ab, ac) == zero)
			{
				// The points are collinear, return a default value
				return zero;
			}

			// Compute normal vectors of the three planes defined by the vectors
			Vector4Int n1 = Cross(ab, ac);
			Vector4Int n2 = Cross(c - b, a - b);
			Vector4Int n3 = Cross(a - c, b - c);

			// Compute the intersection point of the three planes
			int denom = Dot(n1, Cross(n2, n3));
			Vector4Int p = (-n1.w * Cross(n2, n3) - n2.w * Cross(n3, n1) - n3.w * Cross(n1, n2)) / denom;

			return p;
		}

		/// <summary>
		///     Returns the slope between vectors a and b.
		/// </summary>
		public static double Slope(Vector4Int a, Vector4Int b)
		{
			double dx = b.x - a.x;
			double dy = b.y - a.y;
			double dz = b.z - a.z;
			double dw = b.w - a.w;

			if (dx == 0 && dy == 0 && dz == 0 && dw == 0)
			{
				// The two points are the same, so the slope is undefined
				return double.NaN;
			}
			else
			{
				// Calculate the 4D slope using the formula: slope = deltaY / deltaX
				return Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw) / Math.Sqrt(4 * (dx * dx + dy * dy + dz * dz + dw * dw));
			}
		}
		/// <summary>
		///     Returns the slope between this vector and another vector.
		/// </summary>
		public double Slope(Vector4Int v)
		{
			double dx = v.x - x;
			double dy = v.y - y;
			double dz = v.z - z;
			double dw = v.w - w;

			if (dx == 0 && dy == 0 && dz == 0 && dw == 0)
			{
				// The two points are the same, so the slope is undefined
				return double.NaN;
			}
			else
			{
				// Calculate the 4D slope using the formula: slope = deltaY / deltaX
				return Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw) / Math.Sqrt(4 * (dx * dx + dy * dy + dz * dz + dw * dw));
			}
		}

		/// <summary>
		///     Reflects a vector off the plane defined by a normal.
		/// </summary>
		public static Vector4Int Reflect(Vector4Int inDirection, Vector4Int inNormal)
		{
			int num = -2 * Dot(inNormal, inDirection);
			return new Vector4Int(
				num * inNormal.x + inDirection.x,
				num * inNormal.y + inDirection.y,
				num * inNormal.z + inDirection.z,
				num * inNormal.w + inDirection.w
			);
		}
		/// <summary>
		///     Reflects this vector off the plane defined by a normal.
		/// </summary>
		public Vector4Int Reflect(Vector4Int inNormal)
		{
			int num = -2 * Dot(inNormal, this);
			int rfx = num * inNormal.x + x;
			int rfy = num * inNormal.y + y;
			int rfz = num * inNormal.z + z;
			int rfw = num * inNormal.w + w;
			x = rfx;
			y = rfy;
			z = rfz;
			w = rfw;
			return new Vector4Int(rfx, rfy, rfz, rfw);
		}

		/// <summary>
		///     Projects a vector onto another vector.
		/// </summary>
		public static Vector4Int Project(Vector4Int v, Vector4Int onNormal)
		{
			int num = Dot(onNormal, onNormal);
			if (num < 1)
			{
				return zero;
			}

			int num2 = Dot(v, onNormal);
			return new Vector4Int(
				onNormal.x * num2 / num,
				onNormal.y * num2 / num,
				onNormal.z * num2 / num,
				onNormal.w * num2 / num
			);
		}
		/// <summary>
		///     Projects this vector onto another vector.
		/// </summary>
		public Vector4Int Project(Vector4Int onNormal)
		{
			int num = Dot(onNormal, onNormal);
			if (num < 1)
			{
				this = zero;
				return zero;
			}

			int num2 = Dot(this, onNormal);
			int px = onNormal.x * num2 / num;
			int py = onNormal.y * num2 / num;
			int pz = onNormal.z * num2 / num;
			int pw = onNormal.w * num2 / num;
			x = px;
			y = py;
			z = pz;
			w = pw;
			return new Vector4Int(px, py, pz, pw);
		}

		/// <summary>
		///     Projects a vector onto a plane defined by a normal orthogonal to the plane.
		/// </summary>
		public static Vector4Int ProjectOnPlane(Vector4Int v, Vector4Int planeNormal)
		{
			int num = Dot(planeNormal, planeNormal);
			if (num < 1)
			{
				return zero;
			}

			int num2 = Dot(v, planeNormal);
			return new Vector4Int(
				v.x - planeNormal.x * num2 / num,
				v.y - planeNormal.y * num2 / num,
				v.z - planeNormal.z * num2 / num,
				v.w - planeNormal.w * num2 / num
			);
		}
		/// <summary>
		///     Projects a vector onto a plane defined by a normal orthogonal to the plane.
		/// </summary>
		public Vector4Int ProjectOnPlane(Vector4Int planeNormal)
		{
			int num = Dot(planeNormal, planeNormal);
			if (num < 1)
			{
				this = zero;
				return zero;
			}

			int num2 = Dot(this, planeNormal);
			int popx = x - planeNormal.x * num2 / num;
			int popy = y - planeNormal.y * num2 / num;
			int popz = z - planeNormal.z * num2 / num;
			int popw = w - planeNormal.w * num2 / num;
			x = popx;
			y = popy;
			z = popz;
			w = popw;
			return new Vector4Int(popx, popy, popz, popw);
		}

		/// <summary>
		///     Calculates the angle between the vectors of 'from' and 'to'.
		/// </summary>
		public static float Angle(Vector4Int from, Vector4Int to)
		{
			float num = (float)Math.Sqrt(Dot(from, from) * Dot(to, to));
			if (num < 1E-15f)
			{
				return 0f;
			}

			float num2 = Mathf.Clamp(Dot(from, to) / num, -1f, 1f);
			return (float)(Math.Acos(num2) * 57.29578f);
		}
		/// <summary>
		///     Calculates the signed angle between the vectors of 'from' and 'to' in relation to 'axis'.
		/// </summary>
		public static float SignedAngle(Vector4Int from, Vector4Int to, Vector4Int axis)
		{
			float num = Angle(from, to);
			float num2 = from.y * to.z - from.z * to.y;
			float num3 = from.z * to.w - from.w * to.z;
			float num4 = from.w * to.x - from.x * to.w;
			float num5 = from.x * to.y - from.y * to.x;
			float num6 = Mathf.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4 + axis.w * num5);
			return num * num6;
		}

		/// <summary>
		///     Calculates the angle between the vectors of 'from' and 'to' in radians.
		/// </summary>
		public static float RadAngle(Vector4Int from, Vector4Int to)
		{
			float dotProduct = Dot(from.normalized, to.normalized);
			return Mathf.Acos(Mathf.Clamp(dotProduct, -1f, 1f));
		}
		/// <summary>
		///     Calculates the signed angle between the vectors of 'from' and 'to' in relation to 'axis' in radians.
		/// </summary>
		public static float SignedRadAngle(Vector4Int from, Vector4Int to, Vector4Int axis)
		{
			float num = RadAngle(from, to);
			float num2 = from.y * to.z - from.z * to.y;
			float num3 = from.z * to.w - from.w * to.z;
			float num4 = from.w * to.x - from.x * to.w;
			float num5 = from.x * to.y - from.y * to.x;
			float num6 = Mathf.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4 + axis.w * num5);
			return num * num6;
		}

		/// <summary>
		///     Returns the distance between vectors a and b.
		/// </summary>
		public static double Distance(Vector4Int a, Vector4Int b)
		{
			int dx = b.x - a.x;
			int dy = b.y - a.y;
			int dz = b.z - a.z;
			int dw = b.w - a.w;
			return (double)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
		}
		/// <summary>
		///     Returns the distance between this vector and another vector.
		/// </summary>
		public double Distance(Vector4Int v)
		{
			int dx = v.x - x;
			int dy = v.y - y;
			int dz = v.z - z;
			int dw = v.w - w;
			return (double)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
		}

		/// <summary>
		///     Returns the magnitude of the given vector.
		/// </summary>
		public static double Magnitude(Vector4Int v)
		{
			return (double)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w);
		}
		/// <summary>
		///     Returns the magnitude of this vector.
		/// </summary>
		public double Magnitude()
		{
			return (double)Math.Sqrt(x * x + y * y + z * z + w * w);
		}

		/// <summary>
		///     Returns the square magnitude of the given vector.
		/// </summary>
		public static double SqrMagnitude(Vector4Int v)
		{
			return v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w;
		}
		/// <summary>
		///     Returns the square magnitude of this vector.
		/// </summary>
		public double SqrMagnitude()
		{
			return x * x + y * y + z * z + w * w;
		}

		/// <summary>
		///     Returns the cube magnitude of the given vector.
		/// </summary>
		public static double CbMagnitude(Vector4Int v)
		{
			return Math.Pow(Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w), 3);
		}
		/// <summary>
		///     Returns the cube magnitude of this vector.
		/// </summary>
		public double CbMagnitude()
		{
			return Math.Pow(Math.Sqrt(x * x + y * y + z * z + w * w), 3);
		}
		/// <summary>
		///     Returns the magnitude raised to the given integer of 'power' of the given vector.
		/// </summary>

		public static double PowMagnitude(Vector4Int v, int power)
		{
			return Math.Pow(Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w), power);
		}
		/// <summary>
		///     Returns the magnitude raised to the given double of 'power' of this vector.
		/// </summary>
		public double PowMagnitude(int power)
		{
			return Math.Pow(Math.Sqrt(x * x + y * y + z * z + w * w), power);
		}
		/// <summary>
		///     Returns the magnitude raised to the given floating-point of 'power' of the given vector.
		/// </summary>
		public static double PowMagnitude(Vector4Int v, float power)
		{
			return Math.Pow(Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w), power);
		}
		/// <summary>
		///     Returns the magnitude raised to the given double of 'power' of this vector.
		/// </summary>
		public double PowMagnitude(float power)
		{
			return Math.Pow(Math.Sqrt(x * x + y * y + z * z + w * w), power);
		}
		/// <summary>
		///     Returns the magnitude raised to the given double of 'power' of the given vector.
		/// </summary>
		public static double PowMagnitude(Vector4Int v, double power)
		{
			return Math.Pow(Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w), power);
		}
		/// <summary>
		///     Returns the magnitude raised to the given double of 'power' of this vector.
		/// </summary>
		public double PowMagnitude(double power)
		{
			return Math.Pow(Math.Sqrt(x * x + y * y + z * z + w * w), power);
		}

		/// <summary>
		///     Returns the exponentiated magnitude of the given vector.
		/// </summary>
		public static double ExpMagnitude(Vector4Int v)
		{
			return (double)Math.Pow(Magnitude(v), Magnitude(v));
		}
		/// <summary>
		///     Returns the exponentiated magnitude of this vector.
		/// </summary>
		public double ExpMagnitude()
		{
			return (double)Math.Pow(Magnitude(this), Magnitude(this));
		}

		/// <summary>
		///     Returns the exponentiated square magnitude of the given vector.
		/// </summary>
		public static double ExpSqrMagnitude(Vector4Int v)
		{
			return (double)Math.Pow(SqrMagnitude(v), SqrMagnitude(v));
		}
		/// <summary>
		///     Returns the exponentiated square magnitude of this vector.
		/// </summary>
		public double ExpSqrMagnitude()
		{
			return (double)Math.Pow(SqrMagnitude(this), SqrMagnitude(this));
		}

		/// <summary>
		///     Returns the exponentiated cube magnitude of the given vector.
		/// </summary>
		public static double ExpCbMagnitude(Vector4Int v)
		{
			return (double)Math.Pow(CbMagnitude(v), CbMagnitude(v));
		}
		/// <summary>
		///     Returns the exponentiated cube magnitude of this vector.
		/// </summary>
		public double ExpCbMagnitude()
		{
			return (double)Math.Pow(CbMagnitude(this), CbMagnitude(this));
		}

		/// <summary>
		///     Returns the exponentiated magnitude raised to the given integer of 'power' of the given vector.
		/// </summary>
		public static double ExpPowMagnitude(Vector4Int v, int power)
		{
			return (double)Math.Pow(PowMagnitude(v, power), PowMagnitude(v, power));
		}
		/// <summary>
		///     Returns the exponentiated magnitude raised to the given integer of 'power' of this vector.
		/// </summary>
		public double ExpPowMagnitude(int power)
		{
			return (double)Math.Pow(PowMagnitude(this, power), PowMagnitude(this, power));
		}
		/// <summary>
		///     Returns the exponentiated magnitude raised to the given floating-point of 'power' of the given vector.
		/// </summary>
		public static double ExpPowMagnitude(Vector4Int v, float power)
		{
			return (double)Math.Pow(PowMagnitude(v, power), PowMagnitude(v, power));
		}
		/// <summary>
		///     Returns the exponentiated magnitude raised to the given floating-point of 'power' of this vector.
		/// </summary>
		public double ExpPowMagnitude(float power)
		{
			return (double)Math.Pow(PowMagnitude(this, power), PowMagnitude(this, power));
		}
		/// <summary>
		///     Returns the exponentiated magnitude raised to the given double of 'power' of the given vector.
		/// </summary>
		public static double ExpPowMagnitude(Vector4Int v, double power)
		{
			return (double)Math.Pow(PowMagnitude(v, power), PowMagnitude(v, power));
		}
		/// <summary>
		///     Returns the exponentiated magnitude raised to the given double of 'power' of this vector.
		/// </summary>
		public double ExpPowMagnitude(double power)
		{
			return (double)Math.Pow(PowMagnitude(this, power), PowMagnitude(this, power));
		}

		/// <summary>
		///     Returns a copy of this vector which has a magnitude of 1.
		/// </summary>
		public static Vector4Int Normalize(Vector4Int v)
		{
			int nx = v.x;
			int ny = v.y;
			int nz = v.z;
			int nw = v.w;
			double mag = Magnitude(v);
			if (mag > 0f)
			{
				double invMag = 1.0 / mag;
				nx = Mathf.RoundToInt((float)(v.x * invMag));
				ny = Mathf.RoundToInt((float)(v.y * invMag));
				nz = Mathf.RoundToInt((float)(v.z * invMag));
				nw = Mathf.RoundToInt((float)(v.w * invMag));
			}
			return new Vector4Int(nx, ny, nz, nw);
		}
		/// <summary>
		///     Makes the given vector have a magnitude of 1.
		/// </summary>
		public void Normalize()
		{
			double mag = Magnitude(this);
			if (mag > 0f)
			{
				double invMag = 1.0 / mag;
				x = Mathf.RoundToInt((float)(x * invMag));
				y = Mathf.RoundToInt((float)(y * invMag));
				z = Mathf.RoundToInt((float)(z * invMag));
				w = Mathf.RoundToInt((float)(w * invMag));
			}
		}

		/// <summary>
		///     Returns a copy of the given vector with every component clamped to the components of min and max.
		/// </summary>
		public static Vector4Int Clamp(Vector4Int v, Vector4Int min, Vector4Int max)
		{
			int cx = Mathf.Clamp(v.x, min.x, max.x);
			int cy = Mathf.Clamp(v.y, min.y, max.y);
			int cz = Mathf.Clamp(v.z, min.z, max.z);
			int cw = Mathf.Clamp(v.w, min.w, max.w);
			return new Vector4Int(cx, cy, cz, cw);
		}
		/// <summary>
		///     Clamps every component of this vector to the components of min and max.
		/// </summary>
		public void Clamp(Vector4Int min, Vector4Int max)
		{
			x = Mathf.Clamp(x, min.x, max.x);
			y = Mathf.Clamp(y, min.y, max.y);
			z = Mathf.Clamp(z, min.z, max.z);
			w = Mathf.Clamp(w, min.w, max.w);
		}
		/// <summary>
		///     Returns a copy of the given vector with every component clamped to the integers of min and max.
		/// </summary>
		public static Vector4Int Clamp(Vector4Int v, int min, int max)
		{
			int cx = Mathf.Clamp(v.x, min, max);
			int cy = Mathf.Clamp(v.y, min, max);
			int cz = Mathf.Clamp(v.z, min, max);
			int cw = Mathf.Clamp(v.w, min, max);
			return new Vector4Int(cx, cy, cz, cw);
		}
		/// <summary>
		///     Clamps every component of this vector to the integers of min and max.
		/// </summary>
		public void Clamp(int min, int max)
		{
			x = Mathf.Clamp(x, min, max);
			y = Mathf.Clamp(y, min, max);
			z = Mathf.Clamp(z, min, max);
			w = Mathf.Clamp(w, min, max);
		}

		/// <summary>
		///     Returns a copy of the given vector with its magnitude clamped to 'maxLength'.
		/// </summary>
		public static Vector4Int ClampMagnitude(Vector4Int v, int maxLength)
		{
			int sqrMagnitude = v.x * v.x + v.y * v.y + v.z * v.z + v.w * v.w;
			if (sqrMagnitude > maxLength * maxLength)
			{
				double magnitude = Mathf.Sqrt(sqrMagnitude);
				double normalizedX = v.x / magnitude;
				double normalizedY = v.y / magnitude;
				double normalizedZ = v.z / magnitude;
				double normalizedW = v.w / magnitude;
				return new Vector4Int(
					Mathf.RoundToInt((float)(normalizedX * maxLength)),
					Mathf.RoundToInt((float)(normalizedY * maxLength)),
					Mathf.RoundToInt((float)(normalizedZ * maxLength)),
					Mathf.RoundToInt((float)(normalizedW * maxLength))
				);
			}

			return v;
		}
		/// <summary>
		///     Clamps the magnitude of this vector to 'maxLength'.
		/// </summary>
		public void ClampMagnitude(int maxLength)
		{
			int sqrMagnitude = x * x + y * y + z * z + w * w;
			if (sqrMagnitude > maxLength * maxLength)
			{
				double magnitude = Mathf.Sqrt(sqrMagnitude);
				double normalizedX = x / magnitude;
				double normalizedY = y / magnitude;
				double normalizedZ = z / magnitude;
				double normalizedW = w / magnitude;
				x = Mathf.RoundToInt((float)(normalizedX * maxLength));
				y = Mathf.RoundToInt((float)(normalizedY * maxLength));
				z = Mathf.RoundToInt((float)(normalizedZ * maxLength));
				w = Mathf.RoundToInt((float)(normalizedW * maxLength));
			}
		}

		/// <summary>
		///     Linearly interpolates between two vectors where t is clamped to [0,1].
		/// </summary>
		public static Vector4Int Lerp(Vector4Int a, Vector4Int b, float t)
		{
			t = Mathf.Clamp01(t);
			int x = Mathf.RoundToInt(Mathf.Lerp(a.x, b.x, t));
			int y = Mathf.RoundToInt(Mathf.Lerp(a.y, b.y, t));
			int z = Mathf.RoundToInt(Mathf.Lerp(a.z, b.z, t));
			int w = Mathf.RoundToInt(Mathf.Lerp(a.w, b.w, t));
			return new Vector4Int(x, y, z, w);
		}
		/// <summary>
		///     Linearly interpolates along two vectors.
		/// </summary>
		public static Vector4Int LerpUnclamped(Vector4Int a, Vector4Int b, float t)
		{
			int x = Mathf.RoundToInt(Mathf.Lerp(a.x, b.x, t));
			int y = Mathf.RoundToInt(Mathf.Lerp(a.y, b.y, t));
			int z = Mathf.RoundToInt(Mathf.Lerp(a.z, b.z, t));
			int w = Mathf.RoundToInt(Mathf.Lerp(a.w, b.w, t));
			return new Vector4Int(x, y, z, w);
		}

		/// <summary>
		///     Hyperspherically interpolates between two vectors where t is clamped to [0,1].
		/// </summary>
		public static Vector4Int Hyperslerp(Vector4Int a, Vector4Int b, float t)
		{
			t = Mathf.Clamp01(t);
			float dot = Dot(a, b);
			dot = Mathf.Clamp(dot, -1f, 1f);
			double theta = Math.Acos(dot) * t;
			Vector4Int relativeVec = b - a * dot;
			relativeVec.Normalize();

			// Use the formula for the great circle between two vectors on a hypersphere.
			return (a * Math.Cos(theta)) + (relativeVec * Math.Sin(theta));
		}
		/// <summary>
		///     Hyperspherically interpolates along two vectors.
		/// </summary>
		public static Vector4Int HyperslerpUnclamped(Vector4Int a, Vector4Int b, float t)
		{
			float dot = Dot(a, b);
			dot = Mathf.Clamp(dot, -1f, 1f);
			double theta = Math.Acos(dot) * t;
			Vector4Int relativeVec = b - a * dot;
			relativeVec.Normalize();

			// Use the formula for the great circle between two vectors on a hypersphere.
			return (a * Math.Cos(theta)) + (relativeVec * Math.Sin(theta));
		}

		/// <summary>
		///     Returns a formatted string for this vector.
		/// </summary>
		public override string ToString()
		{
			return ToString(null, null);
		}
		/// <summary>
		///     Returns a formatted string for this vector with the given numeric format string.
		/// </summary>
		public string ToString(string format)
		{
			return ToString(format, null);
		}
		/// <summary>
		///     Returns a formatted string for this vector with the given numeric format string and the given culture-specific formatting object.
		/// </summary>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (string.IsNullOrEmpty(format))
			{
				format = "F0";
			}

			if (formatProvider == null)
			{
				formatProvider = CultureInfo.InvariantCulture.NumberFormat;
			}

			return VectorTypingString.Format("({0}, {1}, {2}, {3})", x.ToString(format, formatProvider),
				y.ToString(format, formatProvider), z.ToString(format, formatProvider), w.ToString(format, formatProvider));
		}

		/// <summary>
		///     Returns true if the objects are equal.
		/// </summary>
		public override bool Equals(object other)
		{
			if (!(other is Vector4Int))
			{
				return false;
			}

			return Equals((Vector4Int)other);
		}
		/// <summary>
		///     Returns true if the objects are equal.
		/// </summary>
		public bool Equals(Vector4Int other)
		{
			return this == other;
		}

		/// <summary>
		///     Gets the hash code for this vector.
		/// </summary>
		public override int GetHashCode()
		{
			int hashCode = y.GetHashCode();
			int hashCode2 = z.GetHashCode();
			int hashCode3 = w.GetHashCode();
			return x.GetHashCode() ^ (hashCode << 2) ^ (hashCode >> 30) ^ (hashCode2 << 4) ^ (hashCode2 >> 28) ^ (hashCode3 << 6) ^ (hashCode3 >> 26);
		}
	}
}

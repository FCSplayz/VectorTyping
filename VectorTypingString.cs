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
using System.IO;
using System.Text.RegularExpressions;

namespace Numani.TypedFilePath.Infrastructure
{
	internal static class Helpers
	{
		public static string ReplaceSeparator(this string src)
		{
			return src.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
		}

		public static string TrimTailingSeparator(this string src)
		{
			return src.TrimEnd(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
		}

		public static string TrimCurrentDirectoryHeader(this string src)
		{
			return Regex.Replace(src, @"^\./", "");
		}
	}
}

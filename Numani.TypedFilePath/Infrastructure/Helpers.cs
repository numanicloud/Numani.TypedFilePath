using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static string FlatDoubleDotSegments(this string src)
        {
			var split = src.Split('/');
            var stack = new Stack<string>(split.Length);

            foreach (var item in split)
            {
                if (item == ".." && stack.TryPeek(out var peeked) && peeked != "..")
                {
                    stack.Pop();
                }
                else
                {
					stack.Push(item);
                }
            }

            return string.Join("/", stack.Reverse());
        }
	}
}

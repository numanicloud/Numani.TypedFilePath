using System.IO;
using Numani.TypedFilePath.Interfaces;
using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath
{
	public static class Extensions
	{
		public static IFilePath AsFilePath(this string pathString)
		{
			IRouting routing = Path.IsPathRooted(pathString)
				? new AbsoluteRoute()
				: new RelativeRoute();

			return AsFilePath(pathString, routing);
		}

		public static IFilePath AsFilePath(this string pathString, IRouting routing)
		{
			// パス末尾のスラッシュなどがあれば、それを外したものをファイルパスとして扱う
			if (Path.EndsInDirectorySeparator(pathString))
			{
				pathString.TrimEnd(Path.DirectorySeparatorChar);
			}

			if (!Path.HasExtension(pathString))
			{
				return routing.GetFilePath(pathString);
			}

			var baseName = Path.GetFileNameWithoutExtension(pathString);
			var ext = new FileExtension(Path.GetExtension(pathString));
			return routing.GetFilePathWithExtension(baseName, ext);
		}

		public static IDirectoryPath AsDirectoryPath(this string pathString)
		{
			IRouting routing = Path.IsPathRooted(pathString)
				? new AbsoluteRoute()
				: new RelativeRoute();

			// パス末尾にスラッシュが無ければ、それを付与したものをディレクトリパスとして扱う
			if (!Path.EndsInDirectorySeparator(pathString))
			{
				pathString += Path.DirectorySeparatorChar;
			}

			return routing.GetDirectoryPath(pathString);
		}

		public static IFileSystemPath AsAnyPath(this string pathString)
		{
			IFileSystemPath result = Path.EndsInDirectorySeparator(pathString)
				? AsDirectoryPath(pathString)
				: AsFilePath(pathString);

			return result;
		}
	}
}

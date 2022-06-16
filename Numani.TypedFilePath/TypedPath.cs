using System;
using System.IO;
using Numani.TypedFilePath.Interfaces;
using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath
{
	public static partial class TypedPath
	{
		public static IFilePath AsFilePath(this string pathString)
		{
			return Path.IsPathRooted(pathString)
				? AsFilePath(pathString, AbsoluteRoute.Instance)
				: AsFilePath(pathString, RelativeRoute.Instance);
		}

		private static IFilePath AsFilePath
			(this string pathString,
			Func<string, IFilePath> noExt,
			Func<string, FileExtension, IFilePath> withExt)
		{
			// パス末尾のスラッシュなどがあれば、それを外したものをファイルパスとして扱う
			if (Path.EndsInDirectorySeparator(pathString))
			{
				pathString.TrimEnd(Path.DirectorySeparatorChar);
			}

			if (!Path.HasExtension(pathString))
			{
				return noExt(pathString);
			}
			
			var ext = new FileExtension(Path.GetExtension(pathString));
			var baseName = pathString.Replace(ext.WithDot, "");
			return withExt(baseName, ext);
		}
		internal static IFilePath AsFilePath(this string pathString, RoutingBase routingBase)
		{
			return AsFilePath(pathString, routingBase.GetFilePath, routingBase.GetFilePathWithExtension);
		}

		internal static IRelativeFilePath AsFilePath(this string pathString, RelativeRoute routingBase)
		{
			var path = AsFilePath(pathString, routingBase.GetFilePath, routingBase.GetFilePathWithExtension);
			if (path is not IRelativeFilePath relative)
			{
				throw new Exception();
			}
			return relative;
		}

		internal static IAbsoluteFilePath AsFilePath(this string pathString, AbsoluteRoute routingBase)
		{
			var path = AsFilePath(pathString, routingBase.GetFilePath, routingBase.GetFilePathWithExtension);
			if (path is not IAbsoluteFilePath absolute)
			{
				throw new Exception();
			}
			return absolute;
		}

		public static IDirectoryPath AsDirectoryPath(this string pathString)
		{
			RoutingBase routingBase = Path.IsPathRooted(pathString)
				? AbsoluteRoute.Instance
				: RelativeRoute.Instance;

			// パス末尾にスラッシュが無ければ、それを付与したものをディレクトリパスとして扱う
			if (!Path.EndsInDirectorySeparator(pathString))
			{
				pathString += Path.DirectorySeparatorChar;
			}

			return routingBase.GetDirectoryPath(pathString);
		}

		public static IFileSystemPath AsAnyPath(this string pathString)
		{
			IFileSystemPath result = Path.EndsInDirectorySeparator(pathString)
				? AsDirectoryPath(pathString)
				: AsFilePath(pathString);

			return result;
		}

		public static IAbsoluteDirectoryPath GetCurrentDirectory()
		{
			var path = Directory.GetCurrentDirectory();
			return new AbsoluteDirectoryPath(path);
		}
	}
}

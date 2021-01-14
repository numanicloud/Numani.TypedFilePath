using System;
using System.IO;
using Numani.TypedFilePath.Interfaces;
using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath
{
	public static class TypedPath
	{
		public static IFilePath AsFilePath(this string pathString)
		{
			RoutingBase routingBase = Path.IsPathRooted(pathString)
				? AbsoluteRoute.Instance
				: RelativeRoute.Instance;

			return AsFilePath(pathString, routingBase);
		}

		public static IFilePath AsFilePath(this string pathString, RoutingBase routingBase)
		{
			// パス末尾のスラッシュなどがあれば、それを外したものをファイルパスとして扱う
			if (Path.EndsInDirectorySeparator(pathString))
			{
				pathString.TrimEnd(Path.DirectorySeparatorChar);
			}

			if (!Path.HasExtension(pathString))
			{
				return routingBase.GetFilePath(pathString);
			}

			var baseName = Path.GetFileNameWithoutExtension(pathString);
			var ext = new FileExtension(Path.GetExtension(pathString));
			return routingBase.GetFilePathWithExtension(baseName, ext);
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


		public static IAbsoluteFilePath Combine(this IAbsoluteDirectoryPath dir, IRelativeFilePath file)
		{
			return Combine(dir, file, dir.AbsoluteRoute.GetFilePath);
		}

		public static IAbsoluteFilePathExt Combine(this IAbsoluteDirectoryPath dir, IRelativeFilePathExt file)
		{
			return CombineExt(dir, file, dir.AbsoluteRoute.GetFilePathWithExtension);
		}

		public static IAbsoluteDirectoryPath Combine(this IAbsoluteDirectoryPath dir, IRelativeDirectoryPath dir2)
		{
			return Combine(dir, dir2, dir.AbsoluteRoute.GetDirectoryPath);
		}

		public static IRelativeFilePath Combine(this IRelativeDirectoryPath dir, IRelativeFilePath file)
		{
			return Combine(dir, file, dir.RelativeRoute.GetFilePath);
		}

		public static IRelativeFilePathExt Combine(this IRelativeDirectoryPath dir, IRelativeFilePathExt file)
		{
			return CombineExt(dir, file, dir.RelativeRoute.GetFilePathWithExtension);
		}

		public static IRelativeDirectoryPath Combine(this IRelativeDirectoryPath dir, IRelativeDirectoryPath dir2)
		{
			return Combine(dir, dir2, dir.RelativeRoute.GetDirectoryPath);
		}

		private static T Combine<T>(IFileSystemPath path1, IFileSystemPath path2, Func<string, T> builder)
		{
			return builder.Invoke(Path.Combine(path1.PathString, path2.PathString));
		}

		private static T CombineExt<T>(IFileSystemPath path1, IFilePathWithExtension path2, Func<string, FileExtension, T> builder)
		{
			return builder.Invoke(Path.Combine(path1.PathString, path2.PathBase), path2.Extension);
		}
	}
}

using System;
using System.IO;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath
{
	public static partial class TypedPath
	{
		public static IAbsoluteFilePath Combine(this IAbsoluteDirectoryPath dir, IRelativeFilePath file)
		{
			return Combine<IAbsoluteFilePath>(dir, file, dir.AbsoluteRoute.GetFilePath);
		}

		public static IAbsoluteFilePathExt Combine(this IAbsoluteDirectoryPath dir, IRelativeFilePathExt file)
		{
			return CombineExt<IAbsoluteFilePathExt>(dir, file, dir.AbsoluteRoute.GetFilePathWithExtension);
		}

		public static IAbsoluteDirectoryPath Combine(this IAbsoluteDirectoryPath dir, IRelativeDirectoryPath dir2)
		{
			return Combine<IAbsoluteDirectoryPath>(dir, dir2, dir.AbsoluteRoute.GetDirectoryPath);
		}

		public static IRelativeFilePath Combine(this IRelativeDirectoryPath dir, IRelativeFilePath file)
		{
			return Combine<IRelativeFilePath>(dir, file, dir.RelativeRoute.GetFilePath);
		}

		public static IRelativeFilePathExt Combine(this IRelativeDirectoryPath dir, IRelativeFilePathExt file)
		{
			return CombineExt<IRelativeFilePathExt>(dir, file, dir.RelativeRoute.GetFilePathWithExtension);
		}

		public static IRelativeDirectoryPath Combine(this IRelativeDirectoryPath dir, IRelativeDirectoryPath dir2)
		{
			return Combine<IRelativeDirectoryPath>(dir, dir2, dir.RelativeRoute.GetDirectoryPath);
		}

		private static T Combine<T>(IFileSystemPath path1, IFileSystemPath path2, Func<string, IFileSystemPath> builder)
		{
			var result = builder.Invoke(Path.Combine(path1.PathString, path2.PathString));
			if (result is not T specific)
			{
				throw new Exception();
			}
			return specific;
		}

		private static T CombineExt<T>(IFileSystemPath path1, IFilePathWithExtension path2, Func<string, FileExtension, IFilePathWithExtension> builder)
		{
			var result = builder.Invoke(Path.Combine(path1.PathString, path2.PathBase), path2.Extension);
			if (result is not T specific)
			{
				throw new Exception();
			}
			return specific;
		}

		public static IRelativeFilePathExt WithExtension(this IRelativeFilePath path, FileExtension extension)
		{
			var result = path.RelativeRoute.GetFilePathWithExtension(path.PathString, extension);
			if (result is not IRelativeFilePathExt relative)
			{
				throw new Exception();
			}
			return relative;
		}

		public static IAbsoluteFilePathExt WithExtension(this IAbsoluteFilePath path, FileExtension extension)
		{
			var result = path.AbsoluteRoute.GetFilePathWithExtension(path.PathString, extension);
			if (result is not IAbsoluteFilePathExt absolute)
			{
				throw new Exception();
			}
			return absolute;
		}

		/// <summary>
		/// ファイルパスの末尾から拡張子をひとつだけ取り除いたパスを返します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IRelativeFilePath WithoutExtension(this IRelativeFilePathExt path)
		{
			return path.PathBase.AsFilePath(path.RelativeRoute);
		}

		/// <summary>
		/// ファイルパスの末尾から拡張子をひとつだけ取り除いたパスを返します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IAbsoluteFilePath WithoutExtension(this IAbsoluteFilePathExt path)
		{
			return path.PathBase.AsFilePath(path.AbsoluteRoute);
		}

		/// <summary>
		/// ファイルパスの末尾から拡張子をすべて取り除いたパスを返します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IRelativeFilePath WithoutExtensions(this IRelativeFilePathExt path)
		{
			var newPath = path.WithoutExtension();
			if (newPath is IRelativeFilePathExt withExt)
			{
				return WithoutExtensions(withExt);
			}

			return newPath;
		}

		/// <summary>
		/// ファイルパスの末尾から拡張子をすべて取り除いたパスを返します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IAbsoluteFilePath WithoutExtensions(this IAbsoluteFilePathExt path)
		{
			var newPath = path.WithoutExtension();
			if (newPath is IAbsoluteFilePathExt withExt)
			{
				return WithoutExtensions(withExt);
			}

			return newPath;
		}
	}
}

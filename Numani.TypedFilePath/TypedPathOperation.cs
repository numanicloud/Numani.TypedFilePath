using System;
using System.IO;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath
{
	public static partial class TypedPath
	{
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

		public static IRelativeFilePathExt WithExtension(this IRelativeFilePath path, FileExtension extension)
		{
			return path.RelativeRoute.GetFilePathWithExtension(path.PathString, extension);
		}

		public static IAbsoluteFilePathExt WithExtension(this IAbsoluteFilePath path, FileExtension extension)
		{
			return path.AbsoluteRoute.GetFilePathWithExtension(path.PathString, extension);
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

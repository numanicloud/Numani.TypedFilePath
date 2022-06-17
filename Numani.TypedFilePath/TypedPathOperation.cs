using System;
using System.IO;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath
{
	public static partial class TypedPath
	{
		/// <summary>
		/// 絶対ディレクトリパスの後ろに相対ファイルパスを結合します。
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="file"></param>
		/// <returns>結合によって作られた絶対ファイルパス。</returns>
		public static IAbsoluteFilePath Combine(this IAbsoluteDirectoryPath dir, IRelativeFilePath file)
		{
			return Combine<IAbsoluteFilePath>(dir, file, dir.AbsoluteRoute.GetFilePath);
		}

		/// <summary>
		/// 絶対ディレクトリパスの後ろに相対ファイルパスを結合します。
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="file"></param>
		/// <returns>結合によって作られた絶対ファイルパス。</returns>
		public static IAbsoluteFilePathExt Combine(this IAbsoluteDirectoryPath dir, IRelativeFilePathExt file)
		{
			return CombineExt<IAbsoluteFilePathExt>(dir, file, dir.AbsoluteRoute.GetFilePathWithExtension);
		}

		/// <summary>
		/// 絶対ディレクトリパスの後ろに相対ディレクトリパスを結合します。
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="dir2"></param>
		/// <returns>結合によって作られた絶対ディレクトリパス。</returns>
		public static IAbsoluteDirectoryPath Combine(this IAbsoluteDirectoryPath dir, IRelativeDirectoryPath dir2)
		{
			return Combine<IAbsoluteDirectoryPath>(dir, dir2, dir.AbsoluteRoute.GetDirectoryPath);
		}

		/// <summary>
		/// 相対ディレクトリパスの後ろに相対ファイルパスを結合します。
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="file"></param>
		/// <returns>結合によって作られた相対ディレクトリパス。</returns>
		public static IRelativeFilePath Combine(this IRelativeDirectoryPath dir, IRelativeFilePath file)
		{
			return Combine<IRelativeFilePath>(dir, file, dir.RelativeRoute.GetFilePath);
		}

		/// <summary>
		/// 相対ディレクトリパスの後ろに相対ファイルパスを結合します。
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="file"></param>
		/// <returns>結合によって作られた相対ファイルパス。</returns>
		public static IRelativeFilePathExt Combine(this IRelativeDirectoryPath dir, IRelativeFilePathExt file)
		{
			return CombineExt<IRelativeFilePathExt>(dir, file, dir.RelativeRoute.GetFilePathWithExtension);
		}

		/// <summary>
		/// 相対ディレクトリパスの後ろに相対ディレクトリパスを結合します。
		/// </summary>
		/// <param name="dir"></param>
		/// <param name="dir2"></param>
		/// <returns>結合によって作られた相対ディレクトリパス。</returns>
		public static IRelativeDirectoryPath Combine(this IRelativeDirectoryPath dir, IRelativeDirectoryPath dir2)
		{
			return Combine<IRelativeDirectoryPath>(dir, dir2, dir.RelativeRoute.GetDirectoryPath);
		}

		/// <summary>
		/// 相対ファイルパスの末尾に拡張子をひとつ追加します。
		/// </summary>
		/// <param name="path">ファイルパス。</param>
		/// <param name="extension">追加する拡張子。</param>
		/// <returns>拡張子が追加されたファイルパス。</returns>
		public static IRelativeFilePathExt WithExtension(this IRelativeFilePath path, FileExtension extension)
		{
			var result = path.RelativeRoute.GetFilePathWithExtension(path.PathString, extension);
			if (result is not IRelativeFilePathExt relative)
			{
				throw new Exception();
			}
			return relative;
		}

		/// <summary>
		/// 絶対ファイルパスの末尾に拡張子をひとつ追加します。
		/// </summary>
		/// <param name="path">ファイルパス。</param>
		/// <param name="extension">追加する拡張子。</param>
		/// <returns>拡張子が追加されたファイルパス。</returns>
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
		/// <remarks>拡張子をひとつ取り除いてもまだ拡張子がついている場合、IRelativeFilePathExt の値を返します。</remarks>
		public static IRelativeFilePath WithoutExtension(this IRelativeFilePathExt path)
		{
			return path.PathBase.AsFilePath(path.RelativeRoute);
		}

		/// <summary>
		/// ファイルパスの末尾から拡張子をひとつだけ取り除いたパスを返します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <remarks>拡張子をひとつ取り除いてもまだ拡張子がついている場合、IAbsoluteFilePathExtの値を返します。</remarks>
		public static IAbsoluteFilePath WithoutExtension(this IAbsoluteFilePathExt path)
		{
			return path.PathBase.AsFilePath(path.AbsoluteRoute);
		}

		/// <summary>
		/// ファイルパスの末尾から拡張子をすべて取り除いたパスを返します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <remarks>すべての拡張子を取り除くので、戻り値が IRelativeFilePathExt になることはありません。</remarks>
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
		/// <remarks>すべての拡張子を取り除くので、戻り値が IAbsoluteFilePathExt になることはありません。</remarks>
		public static IAbsoluteFilePath WithoutExtensions(this IAbsoluteFilePathExt path)
		{
			var newPath = path.WithoutExtension();
			if (newPath is IAbsoluteFilePathExt withExt)
			{
				return WithoutExtensions(withExt);
			}

			return newPath;
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
	}
}

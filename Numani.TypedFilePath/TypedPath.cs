using System;
using System.IO;
using Numani.TypedFilePath.Interfaces;
using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath
{
	public static partial class TypedPath
	{
		/// <summary>
		/// パス文字列をファイルパスとして型つきファイルパスに変換します。
		/// </summary>
		/// <param name="pathString">パス文字列。</param>
		/// <returns>ファイルパスであることが保証されたパス。</returns>
		public static IFilePath AsFilePath(this string pathString)
		{
			return Path.IsPathRooted(pathString)
				? AsFilePath(pathString, AbsoluteRoute.Instance)
				: AsFilePath(pathString, RelativeRoute.Instance);
		}

		/// <summary>
		/// パス文字列をディレクトリパスとして型つきファイルパスに変換します。
		/// </summary>
		/// <param name="pathString">パス文字列。</param>
		/// <returns>ディレクトリパスであることが保証されたパス。</returns>
		public static IDirectoryPath AsDirectoryPath(this string pathString)
		{
			RoutingBase routingBase = Path.IsPathRooted(pathString)
				? AbsoluteRoute.Instance
				: RelativeRoute.Instance;

			return routingBase.GetDirectoryPath(pathString);
		}

		/// <summary>
		/// パス文字列の末尾がディレクトリ区切り記号であるかどうかに基づいて、パス文字列を型つきファイルパスに変換します。
		/// </summary>
		/// <param name="pathString">パス文字列</param>
		/// <returns>パス文字列の末尾がディレクトリ区切り記号であれば IDirectoryPath。そうでなければ IFilePath。</returns>
		public static IFileSystemPath AsAnyPath(this string pathString)
		{
			IFileSystemPath result = EndsInDirectorySeparator(pathString)
				? AsDirectoryPath(pathString)
				: AsFilePath(pathString);

			return result;
		}

		/// <summary>
		/// アプリケーションのカレントディレクトリのパスを取得します。
		/// </summary>
		/// <returns>カレントディレクトリのパス。</returns>
		public static IAbsoluteDirectoryPath GetCurrentDirectory()
		{
			var path = Directory.GetCurrentDirectory();
			return new AbsoluteDirectoryPath(path);
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

		private static bool EndsInDirectorySeparator(string path)
		{
			return path.EndsWith(Path.DirectorySeparatorChar)
				|| path.EndsWith(Path.AltDirectorySeparatorChar);
		}

		private static IFilePath AsFilePath
			(this string pathString,
			Func<string, IFilePath> noExt,
			Func<string, FileExtension, IFilePath> withExt)
		{
			if (!Path.HasExtension(pathString))
			{
				return noExt(pathString);
			}

			var ext = new FileExtension(Path.GetExtension(pathString));
			var baseName = pathString.Replace(ext.ExtensionString, "");
			return withExt(baseName, ext);
		}
	}
}

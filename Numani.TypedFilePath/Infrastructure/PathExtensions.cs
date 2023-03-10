using System;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Infrastructure
{
	public static class PathExtensions
	{
		/// <summary>
		/// 指定された文字列をファイルパスの型に変換します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IFilePath AssertFilePath(this string path) =>
			path.AsFilePath();

		/// <summary>
		/// 指定された文字列をディレクトリパスの型に変換します。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IDirectoryPath AssertDirectoryPath(this string path) =>
			path.AsDirectoryPath();

		/// <summary>
		/// 指定された文字列を拡張子付きファイルパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IFilePathWithExtension AssertFilePathExt(this string path) =>
			path.AsFilePath() as IFilePathWithExtension
			?? throw new ArgumentOutOfRangeException($"{path} is not path with extension.");

		/// <summary>
		/// 指定された文字列を相対ディレクトリパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IRelativeDirectoryPath AssertRelativeDirectoryPath(this string path) =>
			path.AsDirectoryPath() as IRelativeDirectoryPath
			?? throw new ArgumentOutOfRangeException($"{path} is not relative directory path.");

		/// <summary>
		/// 指定された文字列を絶対ディレクトリパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IAbsoluteDirectoryPath AssertAbsoluteDirectoryPath(this string path) =>
			path.AsDirectoryPath() as IAbsoluteDirectoryPath
			?? throw new ArgumentOutOfRangeException($"{path} is not absolute directory path.");

		/// <summary>
		/// 指定された文字列を相対ファイルパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IRelativeFilePath AssertRelativeFilePath(this string path)
        {
            var relativeFilePath = path.AsAnyPath() as IRelativeFilePath;
            return relativeFilePath
                ?? throw new ArgumentOutOfRangeException($"{path} is not relative file path.");
        }

        /// <summary>
		/// 指定された文字列を絶対ファイルパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IAbsoluteFilePath AssertAbsoluteFilePath(this string path) =>
			path.AsAnyPath() as IAbsoluteFilePath
			?? throw new ArgumentOutOfRangeException($"{path} is not absolute file path.");

		/// <summary>
		/// 指定された文字列を拡張子付きの相対ファイルパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IRelativeFilePathExt AssertRelativeFilePathExt(this string path) =>
			path.AsAnyPath() as IRelativeFilePathExt
			?? throw new ArgumentOutOfRangeException($"{path} is not relative file path with any extensions.");

		/// <summary>
		/// 指定された文字列を拡張子付きの絶対ファイルパスの型に変換します。変換できない場合、例外を投げます。
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public static IAbsoluteFilePathExt AssertAbsoluteFilePathExt(this string path) =>
			path.AsAnyPath() as IAbsoluteFilePathExt
			?? throw new ArgumentOutOfRangeException($"{path} is not absolute file path with any extensions.");
	}
}

using System;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Infrastructure
{
	public static class PathExtensions
	{
		public static IRelativeDirectoryPath AssertRelativeDirectoryPath(this string path) =>
			path.AsAnyPath() is not IRelativeDirectoryPath relative
				? throw new ArgumentOutOfRangeException($"{path} is not relative directory path.")
				: relative;

		public static IAbsoluteDirectoryPath AssertAbsoluteDirectoryPath(this string path) =>
			path.AsAnyPath() is not IAbsoluteDirectoryPath absolute
				? throw new ArgumentOutOfRangeException($"{path} is not absolute directory path.")
				: absolute;

		public static IRelativeFilePath AssertRelativeFilePath(this string path) =>
			path.AsAnyPath() is not IRelativeFilePath relative
				? throw new ArgumentOutOfRangeException($"{path} is not relative file path.")
				: relative;

		public static IAbsoluteFilePath AssertAbsoluteFilePath(this string path) =>
			path.AsAnyPath() is not IAbsoluteFilePath absolute
				? throw new ArgumentOutOfRangeException($"{path} is not absolute file path.")
				: absolute;

		public static IRelativeFilePathExt AssertRelativeFilePathExt(this string path) =>
			path.AsAnyPath() is not IRelativeFilePathExt relative
				? throw new ArgumentOutOfRangeException($"{path} is not relative file path with any extensions.")
				: relative;

		public static IAbsoluteFilePathExt AssertAbsoluteFilePathExt(this string path) =>
			path.AsAnyPath() is not IAbsoluteFilePathExt absolute
				? throw new ArgumentOutOfRangeException($"{path} is not absolute file path with any extensions.")
				: absolute;
	}
}

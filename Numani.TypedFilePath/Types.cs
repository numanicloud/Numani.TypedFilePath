using Numani.TypedFilePath.Infrastructure;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath
{
	internal record FormattedPath(string PathString)
	{
		public string PathString { get; } = PathString
			.ReplaceSeparator()
			.TrimTailingSeparator()
			.TrimCurrentDirectoryHeader()
            .FlatDoubleDotSegments();
	}

	internal record RelativeDirectoryPath(string PathString)
		: FormattedPath(PathString), IRelativeDirectoryPath;

	internal record AbsoluteDirectoryPath(string PathString)
		: FormattedPath(PathString), IAbsoluteDirectoryPath;

	internal record RelativeFilePath(string PathString)
		: FormattedPath(PathString), IRelativeFilePath;

	internal record AbsoluteFilePath(string PathString)
		: FormattedPath(PathString), IAbsoluteFilePath;
	
	internal record PathWithExtension(string PathBase, FileExtension Extension)
		: FormattedPath(PathBase + Extension.ExtensionString);

	internal record RelativeFilePathExt(string PathBase, FileExtension Extension)
		: PathWithExtension(PathBase, Extension), IRelativeFilePathExt;

	internal record AbsoluteFilePathExt(string PathBase, FileExtension Extension)
		: PathWithExtension(PathBase, Extension), IAbsoluteFilePathExt;
}

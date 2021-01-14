using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath.Interfaces
{
	public interface IRelativeFilePath : IFilePath, IRelativePath
	{
	}

	public interface IAbsoluteFilePath : IFilePath, IAbsolutePath
	{
	}

	public interface IRelativeFilePathExt : IFilePathWithExtension, IRelativePath
	{
	}

	public interface IAbsoluteFilePathExt : IFilePathWithExtension, IAbsolutePath
	{
	}

	public interface IRelativeDirectoryPath : IDirectoryPath, IRelativePath
	{
	}

	public interface IAbsoluteDirectoryPath : IDirectoryPath, IAbsolutePath
	{
	}
}

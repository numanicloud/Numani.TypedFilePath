using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath.Interfaces
{
	/// <summary>
	/// 相対ファイルパスで、拡張子の有無を考慮しません。
	/// </summary>
	public interface IRelativeFilePath : IFilePath, IRelativePath
	{
	}

	/// <summary>
	/// 絶対ファイルパスで、拡張子の有無を考慮しません。
	/// </summary>
	public interface IAbsoluteFilePath : IFilePath, IAbsolutePath
	{
	}

	/// <summary>
	/// 相対ファイルパスで、拡張子があることを保証します。
	/// </summary>
	public interface IRelativeFilePathExt : IFilePathWithExtension, IRelativeFilePath
	{
	}

	/// <summary>
	/// 絶対ファイルパスで、拡張子があることを保証します。
	/// </summary>
	public interface IAbsoluteFilePathExt : IFilePathWithExtension, IAbsoluteFilePath
	{
	}

	/// <summary>
	/// 相対ディレクトリパス。
	/// </summary>
	public interface IRelativeDirectoryPath : IDirectoryPath, IRelativePath
	{
	}

	/// <summary>
	/// 絶対ディレクトリパス。
	/// </summary>
	public interface IAbsoluteDirectoryPath : IDirectoryPath, IAbsolutePath
	{
	}
}

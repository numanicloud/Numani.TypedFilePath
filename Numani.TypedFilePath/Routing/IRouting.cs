using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	public interface IRouting
	{
		IFilePath GetFilePath(string pathString);
		IFilePathWithExtension GetFilePathWithExtension(string pathString, FileExtension extension);
		IDirectoryPath GetDirectoryPath(string pathString);
	}
}

using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	class RelativeRoute : IRouting
	{
		IFilePath IRouting.GetFilePath(string pathString)
		{
			return new RelativeFilePath(pathString);
		}

		IFilePathWithExtension IRouting.GetFilePathWithExtension(string pathBase, FileExtension extension)
		{
			return new RelativeFilePathExt(pathBase, extension);
		}

		IDirectoryPath IRouting.GetDirectoryPath(string pathString)
		{
			return new RelativeDirectoryPath(pathString);
		}
	}
}

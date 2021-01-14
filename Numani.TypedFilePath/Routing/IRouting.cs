using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	public abstract class RoutingBase
	{
		public abstract IFilePath GetFilePath(string pathString);
		public abstract IFilePathWithExtension GetFilePathWithExtension(string pathString, FileExtension extension);
		public abstract IDirectoryPath GetDirectoryPath(string pathString);
	}
}

using System.IO;

namespace Numani.TypedFilePath.Interfaces
{
	public interface IFilePath : IFileSystemPath
	{
		public bool Exists() => File.Exists(PathString);
		public FileStream Create() => File.Create(PathString);
		public FileStream OpenRead() => File.OpenRead(PathString);
		public FileStream OpenWrite() => File.OpenWrite(PathString);

		public IFilePathWithExtension WithExtension(FileExtension extension)
		{
			return RoutingInfo.GetFilePathWithExtension(PathString, extension);
		}
	}
}

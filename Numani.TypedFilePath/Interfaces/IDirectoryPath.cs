using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Numani.TypedFilePath.Interfaces
{
	public interface IDirectoryPath : IFileSystemPath
	{
		public bool Exists() => Directory.Exists(PathString);
		public DirectoryInfo Create() => Directory.CreateDirectory(PathString);
		public DirectoryInfo GetInfo() => new DirectoryInfo(PathString);

		public IEnumerable<IFilePath> EnumerateFiles()
		{
			return Directory.EnumerateFiles(PathString)
				.Select(path => TypedPath.AsFilePath(path, RoutingBaseInfo));
		}
	}
}

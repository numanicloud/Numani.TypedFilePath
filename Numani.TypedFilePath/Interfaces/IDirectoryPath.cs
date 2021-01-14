using System.Collections.Generic;
using System.IO;
using System.Linq;
using Numani.TypedFilePath.Routing;

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
				.Select(path => Extensions.AsFilePath(path, RoutingInfo));
		}

		public IFilePath CombineFile<T>(T file) where T : IFilePath, IRelativePath
		{
			return RoutingInfo.GetFilePath(Path.Combine(PathString, file.PathString));
		}

		public IDirectoryPath CombineDirectory<T>(T dir2) where T : IDirectoryPath, IRelativePath
		{
			return RoutingInfo.GetDirectoryPath(Path.Combine(PathString, dir2.PathString));
		}
	}
}

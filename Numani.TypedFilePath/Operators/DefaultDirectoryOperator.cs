using System.IO;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Operators
{
	public class DefaultDirectoryOperator : IDirectoryOperator
	{
		public bool Exists(IDirectoryPath path)
			=> Directory.Exists(path.PathString);

		public void Delete(IDirectoryPath path, bool recursive = false)
			=> Directory.Delete(path.PathString, recursive);

		public void Create(IDirectoryPath path)
			=> Directory.CreateDirectory(path.PathString);
	}
}

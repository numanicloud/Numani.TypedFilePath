using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Operators
{
	public interface IDirectoryOperator
	{
		public bool Exists(IDirectoryPath path);
		public void Delete(IDirectoryPath path, bool recursive = false);
		public void Create(IDirectoryPath path);
	}
}

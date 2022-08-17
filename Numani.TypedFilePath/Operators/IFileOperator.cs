using System.IO;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Operators
{
	public interface IFileOperator
	{
		FileStream Create(IFilePath filePath);
		void Delete(IFilePath filePath);
		bool Exists(IFilePath filePath);

		void WriteAllText(IFilePath filePath, string text);
		void WriteAllBytes(IFilePath filePath, byte[] bytes);
		string ReadAllText(IFilePath filePath);
		byte[] ReadAllBytes(IFilePath filePath);
	}
}

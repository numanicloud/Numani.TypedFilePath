using System.IO;

namespace Numani.TypedFilePath.Infrastructure
{
	public interface IFileOperator
	{
		FileStream Create(string filePath);
		void Delete(string filePath);
		bool Exists(string filePath);

		void WriteAllText(string filePath, string text);
		void WriteAllBytes(string filePath, byte[] bytes);
		string ReadAllText(string filePath);
		byte[] ReadAllBytes(string filePath);
	}
}

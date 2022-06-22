using System.IO;

namespace Numani.TypedFilePath.Infrastructure
{
	public sealed class DefaultFileOperator : IFileOperator
	{
		public FileStream Create(string filePath) => File.Create(filePath);

		public void Delete(string filePath) => File.Delete(filePath);

		public bool Exists(string filePath) => File.Exists(filePath);

		public void WriteAllText(string filePath, string text) => File.WriteAllText(filePath, text);

		public void WriteAllBytes
			(string filePath, byte[] bytes) => File.WriteAllBytes(filePath, bytes);

		public string ReadAllText(string filePath) => File.ReadAllText(filePath);

		public byte[] ReadAllBytes(string filePath) => File.ReadAllBytes(filePath);
	}
}

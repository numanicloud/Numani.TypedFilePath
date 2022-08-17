using System.IO;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Operators
{
	public sealed class DefaultFileOperator : IFileOperator
	{
		public FileStream Create(IFilePath filePath)
			=> File.Create(filePath.PathString);

		public void Delete(IFilePath filePath)
			=> File.Delete(filePath.PathString);

		public bool Exists(IFilePath filePath)
			=> File.Exists(filePath.PathString);

		public void WriteAllText(IFilePath filePath, string text)
			=> File.WriteAllText(filePath.PathString, text);

		public void WriteAllBytes(IFilePath filePath, byte[] bytes)
			=> File.WriteAllBytes(filePath.PathString, bytes);

		public string ReadAllText(IFilePath filePath)
			=> File.ReadAllText(filePath.PathString);

		public byte[] ReadAllBytes(IFilePath filePath)
			=> File.ReadAllBytes(filePath.PathString);
	}
}

using System.IO;

namespace Numani.TypedFilePath.Interfaces
{
	/// <summary>
	/// ファイルパスを扱います。
	/// </summary>
	public interface IFilePath : IFileSystemPath
	{
		/// <summary>
		/// ファイルパスが指しているファイルが存在するかどうかの真偽値を返します。
		/// </summary>
		/// <returns></returns>
		public bool Exists() => File.Exists(PathString);

		/// <summary>
		/// ファイルパスが指している場所にファイルを作成し、書き込み可能なストリームを返します。
		/// </summary>
		/// <returns></returns>
		public FileStream Create() => File.Create(PathString);

		/// <summary>
		/// ファイルパスが指しているファイルを開き、読み取り可能なストリームを返します。
		/// </summary>
		/// <returns></returns>
		public FileStream OpenRead() => File.OpenRead(PathString);

		/// <summary>
		/// ファイルパスが指しているファイルを開き、書き込み可能なストリームを返します。
		/// </summary>
		/// <returns></returns>
		public FileStream OpenWrite() => File.OpenWrite(PathString);
	}
}

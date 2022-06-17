using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Numani.TypedFilePath.Interfaces
{
	/// <summary>
	/// ディレクトリパスを扱います。
	/// </summary>
	public interface IDirectoryPath : IFileSystemPath
	{
		/// <summary>
		/// ディレクトリパスを表す文字列を、末尾にパス区切り記号がついた状態で返します。
		/// </summary>
		public string PathStringWithTrailingSlash => PathString + Path.DirectorySeparatorChar;

		/// <summary>
		/// ディレクトリパスが指すディレクトリが存在するかどうかの真偽値を返します。
		/// </summary>
		/// <returns></returns>
		public bool Exists() => Directory.Exists(PathString);

		/// <summary>
		/// ディレクトリパスが指す場所にディレクトリを作成します。
		/// </summary>
		/// <returns>作成されたディレクトリの DirectoryInfo。</returns>
		public DirectoryInfo Create() => Directory.CreateDirectory(PathString);

		/// <summary>
		/// ディレクトリパスが指すディレクトリの情報を取得します。
		/// </summary>
		/// <returns></returns>
		public DirectoryInfo GetInfo() => new DirectoryInfo(PathString);

		/// <summary>
		/// ディレクトリパスが指すディレクトリ内にあるファイルのファイルパスを列挙します。
		/// </summary>
		/// <returns></returns>
		public IEnumerable<IFilePath> EnumerateFiles()
		{
			return Directory.EnumerateFiles(PathString)
				.Select(path => path.AsFilePath(RoutingBaseInfo));
		}
	}
}

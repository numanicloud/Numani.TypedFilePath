using System.IO;
using Numani.TypedFilePath.Infrastructure;
using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath.Interfaces
{
	/// <summary>
	/// ファイルまたはディレクトリへのパスを扱います。
	/// </summary>
	public interface IFileSystemPath
	{
		/// <summary>
		/// ファイルパスを表す文字列を取得します。
		/// </summary>
		public string PathString { get; }
		internal RoutingBase RoutingBaseInfo { get; }

		/// <summary>
		/// このパスの親ディレクトリを表すパスを取得します。
		/// </summary>
		/// <returns>親ディレクトリのパス。このパスがルートである場合はnull。</returns>
        public IDirectoryPath? GetParentPath()
        {
			return Directory.GetParent(PathString)
                ?.FullName
                .AssertDirectoryPath();
        }
	}
}

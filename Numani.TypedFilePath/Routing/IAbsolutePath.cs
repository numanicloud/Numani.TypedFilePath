using System.IO;
using Numani.TypedFilePath.Infrastructure;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	/// <summary>
	/// 絶対パスを扱います。
	/// </summary>
	public interface IAbsolutePath : IFileSystemPath
	{
		RoutingBase IFileSystemPath.RoutingBaseInfo => AbsoluteRoute.Instance;
		internal AbsoluteRoute AbsoluteRoute => AbsoluteRoute.Instance;

        /// <summary>
		/// この絶対パスの親ディレクトリを表す絶対パスを取得します。
		/// </summary>
		/// <returns>親ディレクトリを表す絶対パス。このパスがルートである場合はnull。</returns>
        public IAbsoluteDirectoryPath? GetParentPath()
        {
            return Directory.GetParent(PathString)
                ?.FullName
                .AssertAbsoluteDirectoryPath();
        }
	}
}

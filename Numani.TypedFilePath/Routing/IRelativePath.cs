using Numani.TypedFilePath.Infrastructure;
using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	/// <summary>
	/// 相対パスを扱います。
	/// </summary>
	public interface IRelativePath : IFileSystemPath
	{
		RoutingBase IFileSystemPath.RoutingBaseInfo => RelativeRoute.Instance;
		internal RelativeRoute RelativeRoute => RelativeRoute.Instance;

		/// <summary>
		/// この相対パスの親ディレクトリとなる相対パスを返します。
		/// </summary>
		/// <returns>親ディレクトリの相対パス。パスが1つの部分しか持たない場合はnull。</returns>
        public IRelativeDirectoryPath? GetParentPath()
        {
            var split = PathString.Split("/");
            if (split.Length == 1)
            {
                return null;
            }

            return string.Join("/", split[..^1])
                .AssertRelativeDirectoryPath();
        }
	}
}

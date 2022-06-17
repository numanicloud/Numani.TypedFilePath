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
	}
}

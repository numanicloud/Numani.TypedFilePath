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
	}
}

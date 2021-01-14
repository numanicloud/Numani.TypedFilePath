using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	public interface IAbsolutePath : IFileSystemPath
	{
		RoutingBase IFileSystemPath.RoutingBaseInfo => AbsoluteRoute.Instance;
		internal AbsoluteRoute AbsoluteRoute => AbsoluteRoute.Instance;
	}
}

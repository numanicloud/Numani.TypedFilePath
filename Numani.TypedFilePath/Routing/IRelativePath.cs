using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	public interface IRelativePath : IFileSystemPath
	{
		RoutingBase IFileSystemPath.RoutingBaseInfo => RelativeRoute.Instance;
		internal RelativeRoute RelativeRoute => RelativeRoute.Instance;
	}
}

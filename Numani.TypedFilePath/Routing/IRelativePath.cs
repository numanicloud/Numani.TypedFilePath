using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	public interface IRelativePath : IFileSystemPath
	{
		IRouting IFileSystemPath.RoutingInfo => new RelativeRoute();
	}
}

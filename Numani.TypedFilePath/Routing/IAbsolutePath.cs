using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	public interface IAbsolutePath : IFileSystemPath
	{
		IRouting IFileSystemPath.RoutingInfo => new AbsoluteRoute();
	}
}

using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath.Interfaces
{
	public interface IFileSystemPath
	{
		public RoutingBase RoutingBaseInfo { get; }
		public string PathString { get; }
	}
}

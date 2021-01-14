using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath.Interfaces
{
	public interface IFileSystemPath
	{
		public IRouting RoutingInfo { get; }
		public string PathString { get; }
	}
}

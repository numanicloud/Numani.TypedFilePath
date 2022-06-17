using Numani.TypedFilePath.Routing;

namespace Numani.TypedFilePath.Interfaces
{
	/// <summary>
	/// ファイルまたはディレクトリへのパスを扱います。
	/// </summary>
	public interface IFileSystemPath
	{
		/// <summary>
		/// ファイルパスを表す文字列を取得します。
		/// </summary>
		public string PathString { get; }
		internal RoutingBase RoutingBaseInfo { get; }
	}
}

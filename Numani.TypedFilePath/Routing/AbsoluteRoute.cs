using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	internal class AbsoluteRoute : RoutingBase
	{
		private static AbsoluteRoute? _instance;
		public static AbsoluteRoute Instance => _instance ??= new AbsoluteRoute();

		private AbsoluteRoute()
		{
		}

		public override IAbsoluteFilePath GetFilePath(string pathString)
		{
			return new AbsoluteFilePath(pathString);
		}

		public override IAbsoluteFilePathExt GetFilePathWithExtension(string pathString, FileExtension extension)
		{
			return new AbsoluteFilePathExt(pathString, extension);
		}

		public override IAbsoluteDirectoryPath GetDirectoryPath(string pathString)
		{
			return new AbsoluteDirectoryPath(pathString);
		}
	}
}

using Numani.TypedFilePath.Interfaces;

namespace Numani.TypedFilePath.Routing
{
	internal class RelativeRoute : RoutingBase
	{
		private static RelativeRoute? _instance;
		public static RelativeRoute Instance => _instance ??= new RelativeRoute();

		private RelativeRoute()
		{
		}

		public override IRelativeFilePath GetFilePath(string pathString)
		{
			return new RelativeFilePath(pathString);
		}

		public override IRelativeFilePathExt GetFilePathWithExtension(string pathBase, FileExtension extension)
		{
			return new RelativeFilePathExt(pathBase, extension);
		}

		public override IRelativeDirectoryPath GetDirectoryPath(string pathString)
		{
			return new RelativeDirectoryPath(pathString);
		}
	}
}

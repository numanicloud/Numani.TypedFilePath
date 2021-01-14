using Numani.TypedFilePath;

namespace Numani.TypedFilePath.Interfaces
{
	public interface IFilePathWithExtension : IFilePath
	{
		string PathBase { get; }
		FileExtension Extension { get; }

		public IFilePath RemoveExtension() => TypedPath.AsFilePath(PathBase);
	}
}

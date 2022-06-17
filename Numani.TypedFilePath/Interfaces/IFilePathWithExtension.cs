namespace Numani.TypedFilePath.Interfaces
{
	/// <summary>
	/// 拡張子付きのファイルパスを扱います。
	/// </summary>
	/// <remarks>ひとつのインスタンスで考慮する拡張子はひとつだけです。</remarks>
	public interface IFilePathWithExtension : IFilePath
	{
		/// <summary>
		/// ファイルパスから拡張子を取り除いた部分の文字列を返します。
		/// </summary>
		string PathBase { get; }

		/// <summary>
		/// 拡張子の情報を返します。
		/// </summary>
		FileExtension Extension { get; }
	}
}

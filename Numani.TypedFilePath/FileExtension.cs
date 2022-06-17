using System;
using System.Linq;

namespace Numani.TypedFilePath
{
	/// <summary>
	/// 拡張子を表現します。
	/// </summary>
	public readonly struct FileExtension
	{
		/// <summary>
		/// 先頭にピリオドのついた形式で拡張子の文字列を取得します。
		/// </summary>
		public string ExtensionString { get; }

		/// <summary>
		/// 先頭にピリオドがついていない形式で拡張子の文字列を取得します。
		/// </summary>
		public string WithoutDot => ExtensionString[1..];

		/// <summary>
		/// 拡張子の文字列を与えて、 FileExtension のインスタンスを作成します。
		/// </summary>
		/// <param name="extensionString">拡張子の文字列。先頭にピリオドをつけるかどうかは任意です。</param>
		/// <exception cref="ArgumentOutOfRangeException">不正な形式の拡張子が指定されました。</exception>
		public FileExtension(string extensionString)
		{
			if (extensionString[1..].Any(x => x == '.'))
			{
				throw new ArgumentOutOfRangeException(nameof(extensionString), extensionString,
					"No character other than the first character of the FileExtension can be a period.");
			}

			if (!extensionString.StartsWith("."))
			{
				extensionString = "." + extensionString;
			}

			ExtensionString = extensionString;
		}
	}
}

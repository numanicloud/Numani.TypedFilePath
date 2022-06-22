using System.IO;
using System.Linq;
using Numani.TypedFilePath.Infrastructure;
using Numani.TypedFilePath.Interfaces;
using Xunit;

namespace Numani.TypedFilePath.Test
{
	public class TypedPathTest
	{
		[Fact]
		public void 拡張子なしの相対ファイルパスを適切なオブジェクトへ変換できる()
		{
			var path = @".\hoge\fuga\piyo";
			var expected = new RelativeFilePath(path);
			var actual = TypedPath.AsAnyPath(path);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 拡張子ありの相対ファイルパスを適切なオブジェクトへ変換できる()
		{
			var path = @".\hoge\fuga\piyo.json";
			var expected = new RelativeFilePathExt(@".\hoge\fuga\piyo", new FileExtension(".json"));
			var actual = TypedPath.AsAnyPath(path);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 拡張子なしの絶対ファイルパスを適切なオブジェクトへ変換できる()
		{
			var path = @"C:\hoge\fuga\piyo";
			var expected = new AbsoluteFilePath(path);
			var actual = TypedPath.AsAnyPath(path);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 拡張子ありの絶対ファイルパスを適切なオブジェクトへ変換できる()
		{
			var path = @"C:\hoge\fuga\piyo.json";
			var expected = new AbsoluteFilePathExt(@"C:\hoge\fuga\piyo", new FileExtension(".json"));
			var actual = TypedPath.AsAnyPath(path);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 相対ディレクトリパスを適切なオブジェクトへ変換できる()
		{
			var path = @".\hoge\fuga\piyo";
			var expected = new RelativeDirectoryPath(path + "\\");
			var actual = TypedPath.AsDirectoryPath(path);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 絶対ディレクトリパスを適切なオブジェクトへ変換できる()
		{
			var path = @"C:\hoge\fuga\piyo";
			var expected = new AbsoluteDirectoryPath(path + "\\");
			var actual = TypedPath.AsDirectoryPath(path);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ファイル一覧を取得できる()
		{
			var files = TypedPath.GetCurrentDirectory().EnumerateFiles()
				.OrderBy(x => x.PathString);
			var expectedFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory())
				.Select(x => x.ReplaceSeparator())
				.OrderBy(x => x);

			var result = files.Zip(expectedFiles)
				.All(t => t.First.PathString == t.Second);

			Assert.True(result);
		}

		[Fact]
		public void PathStringWithTrailingSlashTest()
		{
			IAbsoluteDirectoryPath dir = new AbsoluteDirectoryPath(@"C:/hoge/fuga/piyo");
			Assert.Equal(@"C:/hoge/fuga/piyo/", dir.PathStringWithTrailingSlash);
		}

		[Fact]
		public void カレントディレクトリは存在する()
		{
			Assert.True(TypedPath.GetCurrentDirectory().Exists());
		}

		[Fact]
		public void 相対ディレクトリパスのPathStringは末尾にスラッシュを持たない()
		{
			var path = @"hoge/fuga/piyo";
			var actual = TypedPath.AsDirectoryPath(path + "/");

			Assert.IsType<RelativeDirectoryPath>(actual);
			Assert.Equal(path, actual.PathString);
		}

		[Fact]
		public void 絶対ディレクトリパスのPathStringは末尾にスラッシュを持たない()
		{
			var path = @"C:/hoge/fuga/piyo";
			var actual = TypedPath.AsDirectoryPath(path + "/");

			Assert.IsType<AbsoluteDirectoryPath>(actual);
			Assert.Equal(path, actual.PathString);
		}

		[Fact]
		public void 別種類のパス区切り記号が混じったパスはスラッシュに統一される()
		{
			var path = @"C:/hoge\fuga/piyo";
			var actual = TypedPath.AsDirectoryPath(path);

			Assert.Equal("C:/hoge/fuga/piyo", actual.PathString);
		}

		[Fact]
		public void パス区切り記号がバックスラッシュの場合にスラッシュに統一される()
		{
			var path = @"C:\hoge\fuga\piyo";
			var actual = TypedPath.AsDirectoryPath(path);

			Assert.Equal("C:/hoge/fuga/piyo", actual.PathString);
		}

		[Theory]
		[InlineData("./hoge/fuga/piyo", "hoge/fuga/piyo")]
		[InlineData("./hoge/fuga/piyo.json", "hoge/fuga/piyo.json")]
		public void カレントディレクトリを表すピリオドを既定で削除する(string path, string expected)
		{
			var actual = TypedPath.AsDirectoryPath(path);

			Assert.Equal(expected, actual.PathString);
		}
	}
}

using Numani.TypedFilePath.Interfaces;
using Xunit;

namespace Numani.TypedFilePath.Test
{
	public class OperationTest
	{
		[Fact]
		public void 絶対ディレクトリパスと相対ファイルパスで絶対ファイルパス()
		{
			IAbsoluteDirectoryPath dir = new AbsoluteDirectoryPath(@"C:\hoge\fuga");
			IRelativeFilePath file = new RelativeFilePath(@"piyo");
			Assert.Equal(@"C:\hoge\fuga\piyo", dir.Combine(file).PathString);
		}

		[Fact]
		public void 絶対ディレクトリパスと拡張子つき相対ファイルパスで拡張子付き絶対ファイルパス()
		{
			IAbsoluteDirectoryPath dir = new AbsoluteDirectoryPath(@"C:\hoge\fuga");
			IRelativeFilePathExt file = new RelativeFilePathExt("piyo", new FileExtension(".json"));
			Assert.Equal(@"C:\hoge\fuga\piyo.json", dir.Combine(file).PathString);
		}

		[Fact]
		public void 二つの相対ディレクトリパスを結合できる()
		{
			IRelativeDirectoryPath dir1 = new RelativeDirectoryPath(@"hoge\fuga");
			IRelativeDirectoryPath dir2 = new RelativeDirectoryPath(@"fizz\buzz");
			Assert.Equal(@"hoge\fuga\fizz\buzz", dir1.Combine(dir2).PathString);
		}

		[Fact]
		public void 絶対ディレクトリパスと相対ディレクトリパスを結合できる()
		{
			IAbsoluteDirectoryPath dir1 = new AbsoluteDirectoryPath(@"C:\hoge\fuga");
			IRelativeDirectoryPath dir2 = new RelativeDirectoryPath(@"fizz\buzz");
			Assert.Equal(@"C:\hoge\fuga\fizz\buzz", dir1.Combine(dir2).PathString);
		}

		[Fact]
		public void 相対ディレクトリパスと拡張子つき相対ファイルパスを結合できる()
		{
			IRelativeDirectoryPath dir = new RelativeDirectoryPath(@"hoge\fuga");
			IRelativeFilePathExt
				file = new RelativeFilePathExt(@"piyo", new FileExtension(".json"));
			Assert.Equal(@"hoge\fuga\piyo.json", dir.Combine(file).PathString);
		}

		[Fact]
		public void 相対ディレクトリパスと相対ファイルパスを結合できる()
		{
			IRelativeDirectoryPath dir = new RelativeDirectoryPath(@"hoge\fuga");
			IRelativeFilePath file = new RelativeFilePath("piyo");
			Assert.Equal(@"hoge\fuga\piyo", dir.Combine(file).PathString);
		}
		
		[Fact]
		public void 相対ファイルパスに拡張子を付けられる()
		{
			IRelativeFilePath file = new RelativeFilePath(@"hoge\fuga\piyo");
			var actual = file.WithExtension(new FileExtension(".json"));
			var expected = new RelativeFilePathExt(@"hoge\fuga\piyo", new FileExtension(".json"));
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 絶対ファイルパスに拡張子を付けられる()
		{
			IAbsoluteFilePath file = new AbsoluteFilePath(@"C:\hoge\fuga\piyo");
			var actual = file.WithExtension(new FileExtension(".json"));
			var expected =
				new AbsoluteFilePathExt(@"C:\hoge\fuga\piyo", new FileExtension(".json"));
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void 拡張子付き絶対ファイルパスから拡張子をひとつだけ取り除ける()
		{
			IAbsoluteFilePathExt file =
				new AbsoluteFilePathExt(@"C:\hoge\fuga.json", new FileExtension(".json"));
			var expected = new AbsoluteFilePathExt(@"C:\hoge\fuga", new FileExtension(".json"));
			Assert.Equal(expected, file.WithoutExtension());
		}

		[Fact]
		public void 拡張子付き相対ファイルパスから拡張子をひとつだけ取り除ける()
		{
			IRelativeFilePathExt file =
				new RelativeFilePathExt(@"hoge\fuga.json", new FileExtension(".json"));
			var expected = new RelativeFilePathExt(@"hoge\fuga", new FileExtension(".json"));
			Assert.Equal(expected, file.WithoutExtension());
		}

		[Fact]
		public void 拡張子付き絶対ファイルパスから拡張子をすべて取り除ける()
		{
			IRelativeFilePathExt file =
				new RelativeFilePathExt(@"C:\hoge\fuga.json", new FileExtension(".json"));
			var expected = new RelativeFilePath(@"C:\hoge\fuga");
			Assert.Equal(expected, file.WithoutExtensions());
		}

		[Fact]
		public void 拡張子付き相対ファイルパスから拡張子をすべて取り除ける()
		{
			IRelativeFilePathExt file =
				new RelativeFilePathExt(@"hoge\fuga.json", new FileExtension(".json"));
			var expected = new RelativeFilePath(@"hoge\fuga");
			Assert.Equal(expected, file.WithoutExtensions());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}

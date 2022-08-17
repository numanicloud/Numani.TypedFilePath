using System.Linq;
using Numani.TypedFilePath.Infrastructure;
using Numani.TypedFilePath.Operators;
using Xunit;

namespace Numani.TypedFilePath.Test;

public sealed class IOTest
{
	[Fact]
	public void ディレクトリ内のファイルを列挙できる()
	{
		var dir = TypedPath.GetTemporaryDirectory()
			.Combine("typed-file-path-test".AssertRelativeDirectoryPath());
		var file1 = dir.Combine("file1".AssertRelativeFilePath());
		var file2 = dir.Combine("file2".AssertRelativeFilePath());

		var dirOp = new DefaultDirectoryOperator();
		dirOp.Create(dir);

		try
		{
			var fileOp = new DefaultFileOperator();
			using var x = fileOp.Create(file1);
			using var y = fileOp.Create(file2);

			var actual = dir.EnumerateFiles().ToArray();
			Assert.Contains(file1, actual);
			Assert.Contains(file2, actual);
		}
		finally
		{
			dirOp.Delete(dir, true);
		}
	}

	[Fact]
	public void ディレクトリ内のディレクトリを列挙できる()
	{
		var dir = TypedPath.GetTemporaryDirectory()
			.Combine("typed-file-path-test".AssertRelativeDirectoryPath());
		var dir1 = dir.Combine("dir1".AssertRelativeDirectoryPath());
		var dir2 = dir.Combine("dir2".AssertRelativeDirectoryPath());

		var dirOp = new DefaultDirectoryOperator();
		dirOp.Create(dir);

		try
		{
			dirOp.Create(dir1);
			dirOp.Create(dir2);

			var actual = dir.EnumerateDirectories().ToArray();
			Assert.Contains(dir1, actual);
			Assert.Contains(dir2, actual);
		}
		finally
		{
			dirOp.Delete(dir, true);
		}
	}
}
using System;
using Numani.TypedFilePath.Infrastructure;
using Xunit;

namespace Numani.TypedFilePath.Test;

public class AssertionTest
{
	[Fact]
	public void 相対ファイルパスを絶対ファイルパスとして扱うことはできない()
	{
		Assert.Throws<ArgumentOutOfRangeException>(() =>
		{
			"./path/file".AssertAbsoluteFilePath();
		});
	}

	[Fact]
	public void 絶対ファイルパスを相対ファイルパスとして扱うことはできない()
	{
		Assert.Throws<ArgumentOutOfRangeException>(() =>
		{
			"Q:/path/file".AssertRelativeFilePath();
		});
	}
}
using Numani.TypedFilePath.Infrastructure;
using Xunit;

namespace Numani.TypedFilePath.Test;

public class RelativeTest
{
    [Fact]
    public void ファイルパスの最後の部分を取得できる()
    {
        var actual = "Q:/Hoge/Fuga/Piyo.txt".AssertFilePath()
            .GetLastSegment();
        Assert.Equal("Piyo.txt", actual.PathString);
    }

    [Fact]
    public void 相対ファイルパスの親パスを取得できる()
    {
        var actual = "./Hoge/Fuga.txt".AssertRelativeFilePath()
            .GetParentPath();
        Assert.Equal("Hoge", actual?.PathString);
    }

    [Fact]
    public void 絶対ファイルパスの親パスを取得できる()
    {
        var actual = "Q:/Hoge/Fuga.txt".AssertAbsoluteFilePath()
            .GetParentPath();
        Assert.Equal("Q:/Hoge", actual?.PathString);
    }

    [Fact]
    public void 相対ディレクトリパスの親パスを取得できる()
    {
        var actual = "./Hoge/Fuga/".AssertRelativeDirectoryPath()
            .GetParentPath();
        Assert.Equal("Hoge", actual?.PathString);
    }

    [Fact]
    public void 絶対ディレクトリパスの親パスを取得できる()
    {
        var actual = "Q:/Hoge/Fuga/".AssertAbsoluteDirectoryPath()
            .GetParentPath();
        Assert.Equal("Q:/Hoge", actual?.PathString);
    }

    [Fact]
    public void 部分を1つしか持たない相対パスの親パスはnullとして扱う()
    {
        var actual = "./Hoge.txt".AssertRelativeFilePath()
            .GetParentPath();
        Assert.Null(actual);
    }

    [Fact]
    public void ルートディレクトリを表す絶対パスの親パスはnullとして扱う()
    {
        var actual = "Q:/".AssertAbsoluteDirectoryPath()
            .GetParentPath();
        Assert.Null(actual);
    }
}
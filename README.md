# Numani.TypedFilePath

ファイルパスの文字列を扱いやすくするためのライブラリです。

ファイルパスの持つ性質を以下のように型で表現します。

![RelativeFilePath, RelativeFilePathExt, AbsoluteFilePath, AbsoluteFilePathExt, RelativeDirectoryPath, AbsoluteDirectoryPath](Documents/types.png)

## 機能

### TypedPath クラス

いくつかのファクトリーメソッドを持ちます。これにより、`string` 型で表現されたパスから、各種インターフェース型を実装するオブジェクトを生成できます。

また、カレントディレクトリのパスを取得する機能、パスを結合する機能があります。

### 各種インターフェース

以下のようなインターフェースがあります。

- `IFileSystemPath`
- `IFilePath`
- `IDirectoryPath`
- `IFilePathWithExtension`
- `IRelativePath`
- `IAbsolutePath`

これらを合成したインターフェースがあります。

- `IRelativeFilePath`
- `IRelativeFilePathExt`
- `IAbsoluteFilePath`
- `IAbsoluteFilePathExt`
- `IRelativeDirectoryPath`
- `IAbsoluteDirectoryPath`

ライブラリのユーザーはこれらインターフェース型にのみアクセスでき、具体的な型は内部に閉じ込められています。

## 基本的な使い方

`TypedPath.AsFilePath` メソッドなどを用いてオブジェクトを生成したら、本当に目的の型に解釈されたのかをパターンマッチングを使って確かめてから使います。

```csharp
// 使い方例

// 相対パスだと思っていたのに絶対パスだった場合などにはマッチしないパターンマッチング
if (TypedPath.AsFilePath("./Hoge/Fuga.txt") is IRelativeFilePathExt rfpe)
{
    // 想定通りに解釈されたならそれを使っていろいろする
    return rfpe;
}

// 想定通りに解釈されなかった場合の処理もご自由にどうぞ
throw new Exception();
```

一度型つきファイルパスに変換したなら、その後は`型つきファイルパス → 型つきファイルパス`の変換メソッドが豊富に用意されているので、それほどパターンマッチングまみれにならずにコードを書けるかと思います。
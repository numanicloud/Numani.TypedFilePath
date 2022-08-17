# Numani.TypedFilePath

ファイルパスの文字列を扱いやすくするためのライブラリです。

ファイルパスの持つ性質を以下のように型で表現します。

![RelativeFilePath, RelativeFilePathExt, AbsoluteFilePath, AbsoluteFilePathExt, RelativeDirectoryPath, AbsoluteDirectoryPath](Documents/types.png)

**Unityからも利用可能です。** 以下のgit urlをPackage Managerで指定してください。
```
https://github.com/NumAniCloud/Numani.TypedFilePath.git#upm-v0.1.0
```

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

`AssertRelativeFilePathExt` 拡張メソッドなどを用いて、文字列を型付きファイルパスのオブジェクトに変換することができます。

```csharp
IRelativeFilePathExt path = ".\\Hoge\\Fuga.txt".AssertRelativeFilePathExt();
```

一度型つきファイルパスに変換したなら、その後は`型つきファイルパス → 型つきファイルパス`の変換メソッドを使ってファイルパスを扱うことができます。

また、変換用の拡張メソッドは、文字列の形式が対象の型に合わない場合に例外を発生させます。

```csharp
// カレントディレクトリからの相対ファイルパスを絶対ファイルパスに変換しようとしているので、例外が投げられる
IAbsoluteFilePath path = ".\\Hoge\\Fuga.txt".AssertAbsoluteFilePath();
```

## 機能

### Combine

型つきファイルパスどうしを結合することができます。

```csharp
IRelativeDirectoryPath dir = ".\\Hoge\\Fuga".AssertRelativeDirectoryPath();
IRelativeFilePath file = "file.txt".AssertRelativeFilePath();

// "./Hoge/Fuga/file.txt" と表示される
Console.WriteLine(dir.Combine(file).PathString);
```

### WithExtension

ファイルパスに拡張子を付けたり外したりできます。

```csharp
var file = "README".AssertRelativeFilePath();
var withExt = file.WithExtension(new FileExtension(".md"));

// "README.md" と表示される
Console.WriteLine(withExt.PathString);
```

```csharp
var file = "README.md".AssertRelativeFilePathExt();
var without = file.WithoutExtension();

// "README" と表示される
Console.WriteLine(without.PathString);
```

### ファイル操作

型つきファイルパスから直接ファイルを操作することもできます。

```csharp
var file = "README.md".AssertRelativeFilePath();

// ファイルが存在するかどうか確認
if (!file.Exists())
{
    // ファイルを作成する
    using var stream = file.OpenCreate();
}
```

### ファイルやディレクトリの列挙

`IDirectoryPath.EnumerateFiles` メソッドを使って、ディレクトリ内のファイルパスを型付きで列挙することができます。

`IDirectoryPath.EnumerateDirectories` メソッドを使って、ディレクトリ内のディレクトリを型付きで列挙することができます。

## パターンマッチング

文字列を型付きファイルパスに変換するとき、失敗した場合に例外を投げる以外の処理をしたいときにはパターンマッチングを使う方法があります。

```csharp
if ("Readme.md".AsAnyPath() is not IRelativeFilePath relative)
{
    return;
}
Console.WriteLine(relative.PathString);
```
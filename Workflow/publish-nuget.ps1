$project = "../Numani.TypedFilePath/Numani.TypedFilePath.csproj"

$version = nbgv get-version -p $project -v NugetPackageVersion
dotnet pack $project -o Pack/ -v minimal -p:PackageVersion=$version

$key = Get-Content ./NuGetApiKey.txt

dotnet nuget push "Pack/Numani.TypedFilePath.${version}.nupkg" -k $key -s https://api.nuget.org/v3/index.json
dotnet publish -c Release -r win10-x64 .\src\FluentMigrator.Console\FluentMigrator.Console.NetStandard.csproj
C:\rot\nuget.exe pack .\packages\FluentMigrator.Tools.NetStandard.nuspec
dotnet pack -c Release .\src\FluentMigrator\FluentMigrator.NetStandard.csproj
dotnet pack -c Release .\src\FluentMigrator.Runner\FluentMigrator.Runner.NetStandard.csproj
set PKG_VER=2017.1.2
nuget pack -Prop Configuration=Release -Version %PKG_VER% CommonMVC/CommonMVC.nuspec -o  ../NugetPackages
nuget pack -Prop Configuration=Release -Version %PKG_VER% CommonMVC.Interfaces/CommonMVC.Interfaces.nuspec   -o  ../NugetPackages
pause


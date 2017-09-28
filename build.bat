@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=.nuget\nuget.exe
if "%nuget%" == "" (
	set nuget=nuget
)

%nuget% restore ./

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild GuiStracini.Mandae.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\lib
mkdir Build\lib\net47

%nuget% pack "GuiStracini.Mandae\GuiStracini.Mandae.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"

@echo off
cls
if not exist ".\tools\FAKE" (
	echo Installing Fake
	".nuget\NuGet.exe" "Install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion"
)

if not exist ".\packages\NUnit.Runners" (
    echo Installing NUnit Runners
     ".nuget\nuget.exe" "Install" "NUnit.Runners" "-OutputDirectory" "packages" "-ExcludeVersion"
)

"packages\FAKE\tools\Fake.exe" build.fsx
pause 
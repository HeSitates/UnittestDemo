@ECHO OFF
cd /d %~dp0

del /q msbuild.log 2> nul > nul
del /s /q packages\*.* 2> nul > nul
rmdir /s /q packages 2> nul > nul

IF NOT EXIST Calculator\NUL GOTO NOCALCULATOR
del   /s /q Calculator\bin\*.* 2> nul > nul
rmdir /s /q Calculator\bin     2> nul > nul
del   /s /q Calculator\obj\*.* 2> nul > nul
rmdir /s /q Calculator\obj     2> nul > nul

del   /s /q Calculator.Tests\bin\*.* 2> nul > nul
rmdir /s /q Calculator.Tests\bin     2> nul > nul
del   /s /q Calculator.Tests\obj\*.* 2> nul > nul
rmdir /s /q Calculator.Tests\obj     2> nul > nul
:NOCALCULATOR

copy LogAnalyzerCleanUp.cmd DISimple\CleanUp.cmd > nul
call DISimple\CleanUp.cmd
copy LogAnalyzerCleanUp.cmd ExtractAndOverride\CleanUp.cmd > nul
call ExtractAndOverride\CleanUp.cmd
copy LogAnalyzerCleanUp.cmd Builder\CleanUp.cmd > nul
call Builder\CleanUp.cmd


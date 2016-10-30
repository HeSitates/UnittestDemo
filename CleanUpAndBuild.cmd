@ECHO OFF
cd /d %~dp0

SET MSBUILD="c:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

call CleanUp.cmd

nuget restore CalculatorDemo.sln -MSBuildVersion 14 -verbosity quiet
%MSBUILD% CalculatorDemo.sln @DemoBuild.rsp

nuget restore DISimple\LogAnalyzer.sln -MSBuildVersion 14 -verbosity quiet
%MSBUILD% DISimple\LogAnalyzer.sln @DemoBuild.rsp

nuget restore ExtractAndOverride\LogAnalyzer.sln -MSBuildVersion 14 -verbosity quiet
%MSBUILD% ExtractAndOverride\LogAnalyzer.sln @DemoBuild.rsp

nuget restore Builder\LogAnalyzer.sln -MSBuildVersion 14 -verbosity quiet
%MSBUILD% Builder\LogAnalyzer.sln @DemoBuild.rsp


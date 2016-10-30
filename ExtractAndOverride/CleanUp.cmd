@ECHO OFF
del /s /q %~dp0%packages\*.* 2> nul > nul
rmdir /s /q %~dp0%packages 2> nul > nul

del   /s /q %~dp0%LogAnalyzer.BLL\bin\*.* 2> nul > nul
rmdir /s /q %~dp0%LogAnalyzer.BLL\bin 2> nul > nul
del   /s /q %~dp0%LogAnalyzer.BLL\obj\*.* 2> nul > nul
rmdir /s /q %~dp0%LogAnalyzer.BLL\obj 2> nul > nul

del   /s /q %~dp0%LogAnalyzer.BLL.Tests\bin\*.* 2> nul > nul
rmdir /s /q %~dp0%LogAnalyzer.BLL.Tests\bin 2> nul > nul
del   /s /q %~dp0%LogAnalyzer.BLL.Tests\obj\*.* 2> nul > nul
rmdir /s /q %~dp0%LogAnalyzer.BLL.Tests\obj 2> nul > nul


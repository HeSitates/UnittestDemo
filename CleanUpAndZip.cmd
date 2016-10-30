@ECHO OFF
cd /d %~dp0

call CleanUp.cmd

cd %~dp0%..

IF EXIST UnittestDemo.zip del UnittestDemo.zip
powershell.exe -nologo -noprofile -command "& { Add-Type -A 'System.IO.Compression.FileSystem'; [IO.Compression.ZipFile]::CreateFromDirectory('UnittestDemo', 'UnittestDemo.zip'); }"

cd %~dp0

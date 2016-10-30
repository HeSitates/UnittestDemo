@ECHO OFF
cls
REM nunit Calculator.Tests\bin\Debug\MyCalculator.BLL.Test.dll --where "cat == TestCategory" %*
REM nunit = nunit3-console --noresult --labels:All %*
nunit3-console --noresult --labels:All Calculator.Tests\bin\Debug\MyCalculator.BLL.Test.dll --where "cat != TestCategory" %*

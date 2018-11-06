@ECHO OFF

REM #############################################################################################################
REM #### ILMergeHelper.bat
REM #### A utility to perform ILMerge using the Post-build event from the Visual Studio project
REM #### Author: Weizh Chang
REM ####
REM #### Usage: ILMergeHelper.bat <targetDir> <targetFileName> <solutionName> <inputAssemblies> [cleanAssemblies]
REM ####
REM #### Example (set in Post-build event): 
REM #### ILMergeHelper.bat $(TargetDir) $(TargetFileName)  "support*.dll" "support*.dll"
REM #############################################################################################################

@ECHO ON

REM #### Set variables from arguments

SET targetDir=%1
CALL :dequote targetDir
Echo %targetDir%

SET targetFileName=%2
CALL :dequote targetFileName
Echo %targetFileName%

SET inputAssemblies=%3
SET inputAssemblies=%inputAssemblies:"=%

SET cleanAssemblies=%4
IF (%cleanAssemblies%)==() SET cleanAssemblies="%inputAssemblies%"
SET cleanAssemblies=%cleanAssemblies:"=%

SET mergedDir=%targetDir%..\ReleaseMerged\

REM #### Set the merged file name
SET mergedFileName=%targetFileName%

REM #### Remove existing merged directory
IF EXIST %mergedDir% RD /S /Q %mergedDir%

REM #### Copy all contents from the build target folder to the merged folder
XCOPY %targetDir%* %mergedDir% /i /E /Y /Q
CD /D %mergedDir%

REM #### Perform ILMerge
%~dp0ILMerge /targetplatform:v4,"C:\Windows\Microsoft.NET\Framework\v4.0.30319" /lib:%mergedDir% /wildcards /allowDup /ndebug /out:%mergedDir%%mergedFileName% %targetFileName% %inputAssemblies%

REM #### Delete all assemblies that have been merged
DEL /Q %cleanAssemblies%
DEL /Q %inputAssemblies%
Goto :eof


:DeQuote
for /f "delims=" %%A in ('echo %%%1%%') do set %1=%%~A
Goto :eof

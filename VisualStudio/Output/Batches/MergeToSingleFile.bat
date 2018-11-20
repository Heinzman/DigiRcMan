SET SUBDIR=%~dp0
ECHO %SUBDIR% 
cd  %SUBDIR% 

ILMerge /closed /targetplatform:v4,"C:\Windows\Microsoft.NET\Framework\v4.0.30319" /out:"DigiSlotMan.exe" "..\DigiSlotMan.exe" "..\ArduinoService.dll" "..\BusinessObjects.dll" "..\CarSound.dll" "..\CentralUnitService.dll" "..\ComputerSpeech.dll" "..\Controls.dll" "..\DomainModels.dll" "..\Exceptions.dll" "..\GhostCarService.dll" "..\HelperClasses.dll" "..\Log.dll" "..\Logger.dll" "..\MockObjects.dll" "..\MouseKeyboardLibrary.dll" "..\MusicPlayer.dll" "..\ParallelPort.dll" "..\ParallelPortDataHandler.dll" "..\PortDataParser.dll" "..\PresentationFramework.dll" "..\RaceActionSound.dll" "..\RaceConsolidationService.dll" "..\RaceControlService.dll" "..\RaceDataService.dll" "..\RaceOptionsService.dll" "..\RaceRecovery.dll" "..\RaceSound.dll" "..\RaceSoundService.dll" "..\RaceStatisticsService.dll" "..\ResourcesService.dll" "..\Serialization.dll" "..\SerialPortReader.dll" "..\VirtualControllerService.dll" "..\WindowsFormsPresenter.dll" "..\WindowsFormsView.dll" 


REM #### Delete all assemblies that have been merged
DEL "..\DigiSlotMan.exe"
DEL "..\*.dll"
DEL "..\*.pdb"
DEL "..\*.xml"

REM #### Copy merged file to build folder
echo D | XCOPY "DigiSlotMan.exe" "..\DigiSlotMan.exe" /Y
echo D | XCOPY "DigiSlotMan.pdb" "..\DigiSlotMan.pdb" /Y

del "DigiSlotMan.exe"
del "DigiSlotMan.pdb"

pause

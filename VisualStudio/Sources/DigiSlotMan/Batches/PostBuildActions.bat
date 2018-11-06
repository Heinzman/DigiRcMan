

REM #### Delete all files except DigiSlotMan* files

DEL "..\*.dll"
REM DEL "..\*.pdb"
DEL "..\*.xml"

set match=*.pdb

REM for %%x in (%match%) do (
REM   if "%%x" NEQ "..\DigiRcMan.pdb" del %%x
REM )

pause

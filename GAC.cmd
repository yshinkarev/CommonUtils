@echo off
set path="c:\Projects\!Components\DotNet\"
rem copy to my assembly folder for gac
copy bin\Release\Common.Utils.??l %path%
rem copy bin\Release\Common.Utils.dll.config %path%
cd %path%
call UpdateSystemDotNet.cmd
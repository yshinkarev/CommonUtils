set name=Common.Utils.dll
set dpath="c:\Копии\PROJECTS\COM\%name%\"
md %dpath%
del /F /Q bin\Debug\*.pdb
del /F /Q bin\Release\*.pdb
rd /S /Q obj
"c:\Program Files\WinRAR\WinRar.exe" a -av- -ed- -ilog.\pack.rar.log -k -m5 -r -s -x@pack_ignore.txt -agYYYY_MM_DD-hh.mm "%dpath%%name%_.rar" *.*

@echo off
echo.
if NOT "%2"=="" goto next1

echo %0 will make the specified number of copies of a file to (by default) the current folder
echo The copies will have '(Copy n) ' added at the beginning of the filename, where 'n' is the count
echo .
echo Useage: %0 copies source_file [destination folder]
echo example: %0 10 test.txt C:\temp
goto end

:next1
if EXIST ".\%2" goto next2
echo file %2 not found
goto end

:next2
set count=%1
set destination=%3
if "%3"=="" set destination=.

:repeat
@echo on
copy %2 "%destination%\(Copy %count%) %2"
@echo off


set /a count=%count%-1 
if %count% LEQ 0 echo Requested number of copies (%1) have been made.
if %count% LEQ 0 goto end

goto repeat

:end
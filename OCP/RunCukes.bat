
set PATH=%PATH%;%cd%\Ruby193\bin\

set PORTABLE_CHROME=%cd%\GoogleChromePortable\GoogleChromePortable.exe

cd cukes
 
call bundle exec cucumber --tags @missionControl

cd.. 
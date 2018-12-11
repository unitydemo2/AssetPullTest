echo Y | rmdir /S Temp
echo Y | rmdir /S Library
echo Y | rmdir /S Container\bin
echo Y | rmdir /S Container\obj
erase Assembly-CSharp-*
erase Container\Container.csproj.user
erase EmbeddedWindow.zip
..\..\..\..\tools\doctools\win32\7z\7z.exe a -tzip EmbeddedWindow ReadMe.txt Assets\* Export\* ProjectSettings\* Container\*
copy EmbeddedWindow.zip ..\..\..\uploads\Main\EmbeddedWindow.zip 
pause

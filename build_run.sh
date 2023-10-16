#!/bin/sh

dotnet publish -c Release Projects/Android/hexr_launcher_Android.csproj
adb install Projects/Android/bin/Release/net7.0-android/technobaboo.hexr_launcher-Signed.apk
adb shell monkey -p technobaboo.hexr_launcher 1

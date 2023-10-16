#!/bin/sh

rm -rf Projects/Android/bin/ Projects/Android/obj/
dotnet publish -c Release
adb install Projects/Android/bin/Release/net7.0-android/technobaboo.hexr_launcher-Signed.apk
#!/bin/sh

rm sk.log
adb shell logcat -c
adb shell monkey -p technobaboo.hexr_launcher 1
adb logcat -b main &> sk.log
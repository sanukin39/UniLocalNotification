# UniLocalNotification
[![UnityVersion](https://img.shields.io/badge/Unity-2017.1.0f3-green.svg)](https://unity3d.com/jp/get-unity/download)
[![AndroidStudioVersion](https://img.shields.io/badge/AndroidStudio-2.3.3-brightgreen.svg)](https://developer.android.com/studio/index.html)
[![License](https://img.shields.io/badge/License-MIT-lightgrey.svg)](https://github.com/sanukin39/UniLocalNotification/blob/master/LICENSE)

---

Simple Local Notification Plugins for Unity

## Description
[UniLocalNotification](https://github.com/sanukin39/UniLocalNotification) - It's a plugin for implementing local notification easily. It can hide processing by platform and register local notification with single code. And several convenient methods are also implemented.

## Example Demo
![](./images/ios_sample.gif)

## Requirement
Unity5 or higher

## Support Platform
iOS, Android

## Usage

### Initialize 
Initialize the plugin. Plese call the method at the beginning of your app every time.

```cs
UniLocalNotification.Initialize();
```

### Register Local Notification 
Register local notification to device. The third argument only use android platform.

```cs
// Notify in 10 seconds
int delay = 10;
UniLocalNotification.Register(delay, "message", "title");
```

### Cancel Local Notification
Cancell all local notifications registered

```cs
UniLocalNotification.CancelAll();
```

### Check Permission
To check whether the user has allowed the notification

```cs
bool isPermitted = UniLocalNotification.IsLocalNotificationPermitted();
```

### Open App Settings
Open application settings (to allow users to register notifications)

```cs
UniLocalNotification.OpenAppSetting();
```

## Install
Use [unitypackage](https://github.com/sanukin39/UniLocalNotification/tree/master/UnityPackage) under the "UnityPackage" folder.

## Change Notification Icon at Android Status Bar
Android status bar icons should be 32-bit PNGs with an alpha channel for transparency. So, you can change the icon by creating your aar library.

1. Open [AndroidLibraryProject](https://github.com/sanukin39/UniLocalNotification/tree/master/AndroidLibraryProject) by Android Studio.
2. Replase notification icon at the "unilocalnotification/src/main/res/drawable/notification_icon.png".

<img src="./images/aar_create_1.png" width="500">

3. Create AAR

    Go to android project root and type "./gradrew assemble".

<img src="./images/aar_create_2.png" width="500">

4. Find AAR At "unilocalnotification/build/outputs/aar/".

<img src="./images/aar_create_3.png" width="500">

5. Replace AAR at the unity project.


## Licence

[MIT](https://github.com/tcnksm/tool/blob/master/LICENCE)

## Author

[sanukin39](https://github.com/sanukin39)

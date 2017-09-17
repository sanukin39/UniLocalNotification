using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sanukin39;

/// <summary>
/// Local Notification Manager
/// </summary>
public class UniLocalNotification
{

    private static ILocalNotification notification;

    /// <summary>
    /// Initialize this instance.
    /// </summary>
    public static void Initialize()
    {
#if UNITY_EDITOR
        notification = new EditorLocalNotification();
#elif UNITY_ANDROID
        notification = new AndroidLocalNotification();
#elif UNITY_IOS
        notification = new IOSLocalNotification();
#endif
        notification.Initialize();
    }

    /// <summary>
    /// Ises the local notification permitted.
    /// </summary>
    /// <returns><c>true</c>, if local notification was permitted, <c>false</c> otherwise.</returns>
    public static bool IsLocalNotificationPermitted()
    {
        return notification.IsNotificationPermitted();
    }

    /// <summary>
    /// Opens the app setting.
    /// </summary>
    public static void OpenAppSetting()
    {
        notification.OpenAppSetting();
    }

    /// <summary>
    /// Register the specified delayTime, message and title.
    /// </summary>
    /// <param name="delayTime">Delay time.</param>
    /// <param name="message">Message.</param>
    /// <param name="title">Title.</param>
    public static void Register(int delayTime, string message, string title = "")
    {
        notification.Register(delayTime, message, title);
    }

    /// <summary>
    /// Cancels all local notification
    /// </summary>
    public static void CancelAll()
    {
        notification.CancelAll();
    }
}


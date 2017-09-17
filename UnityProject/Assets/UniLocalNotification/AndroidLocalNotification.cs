#if UNITY_ANDROID
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sanukin39
{
    public class AndroidLocalNotification : ILocalNotification
    {
        const int MaxRegisterNum = 5;
        const string PackageName = "net.sanukin.unilocalnotification.NotificationSender";

        /// <summary>
        /// Initialization
        /// </summary>
        public void Initialize()
        {
            // Do nothing...
        }

        /// <summary>
        /// Check notification is permitted
        /// </summary>
        /// <returns><c>true</c>, if notification is permitted , <c>false</c> otherwise.</returns>
        public bool IsNotificationPermitted()
        {
            var c = new AndroidJavaClass(PackageName);
            return c.CallStatic<bool>("isNotificationPermitted");
        }

        /// <summary>
        /// Open app setting
        /// </summary>
        public void OpenAppSetting()
        {
            var c = new AndroidJavaClass(PackageName);
            c.CallStatic("openAppSettings");
        }

        /// <summary>
        /// Register local notification
        /// </summary>
        /// <param name="delayTime">Delay time.</param>
        /// <param name="message">Notification Message.</param>
        /// <param name="title">Notification Title.</param>
        public void Register(int delayTime, string message, string title = "")
        {
            var c = new AndroidJavaClass(PackageName);
            for (int i = 0; i < MaxRegisterNum; i++)
            {
                if (!c.CallStatic<bool>("hasPendingIntent", i))
                {
                    c.CallStatic("setNotification", title, message, delayTime, i);
                    break;
                }
            }
        }

        /// <summary>
        /// Cancel all notification
        /// </summary>
        public void CancelAll()
        {
            var c = new AndroidJavaClass(PackageName);
            for (int i = 0; i < MaxRegisterNum; i++)
            {
                if (c.CallStatic<bool>("hasPendingIntent", i))
                {
                    c.CallStatic("cancel", i);
                }
            }
        }
    }
}
#endif

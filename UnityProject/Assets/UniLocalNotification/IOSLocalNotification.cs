#if UNITY_IOS
using System.Runtime.InteropServices;
using NotificationType = UnityEngine.iOS.NotificationType;
using LocalNotification = UnityEngine.iOS.LocalNotification;
using NotificationServices = UnityEngine.iOS.NotificationServices;

namespace Sanukin39 {
    public class IOSLocalNotification : ILocalNotification
    {
        [DllImport("__Internal")]
        static extern void OpenAppSetting_();

        [DllImport("__Internal")]
        static extern bool IsNotificationPermitted_();

        /// <summary>
        /// Ask for permission to notify the user
        /// </summary>
        public void Initialize()
        {
            NotificationServices.RegisterForNotifications(
                NotificationType.Alert |
                NotificationType.Badge |
                NotificationType.Sound);
        }

        /// <summary>
        /// Check notification is permitted
        /// </summary>
        /// <returns><c>true</c>, if notification is permitted , <c>false</c> otherwise.</returns>
        public bool IsNotificationPermitted()
        {
            return IsNotificationPermitted_();
        }

        /// <summary>
        /// Open app setting
        /// </summary>
        public void OpenAppSetting()
        {
            OpenAppSetting_();
        }

        /// <summary>
        /// Register local notification
        /// </summary>
        /// <param name="delayTime">Delay time.</param>
        /// <param name="message">Notification Message.</param>
        /// <param name="title">Notification Title.</param>
        public void Register(int delayTime, string message, string title = "")
        {
            LocalNotification notification = new LocalNotification();
            notification.fireDate = System.DateTime.Now.AddSeconds(delayTime);
            notification.alertBody = message;
            NotificationServices.ScheduleLocalNotification(notification);
        }

        /// <summary>
        /// Cancel all notifications
        /// </summary>
        public void CancelAll()
        {
            NotificationServices.CancelAllLocalNotifications();
        }
    }
}
#endif
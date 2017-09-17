using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sanukin39
{
    /// <summary>
    /// Interface of using local notification
    /// </summary>
    public interface ILocalNotification
    {
        void Initialize();
        bool IsNotificationPermitted();
        void OpenAppSetting();
        void Register(int delayTime, string message, string title);
        void CancelAll();
    }
}
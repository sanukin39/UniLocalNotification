using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sanukin39
{
    public class EditorLocalNotification : ILocalNotification
    {
        public void Initialize()
        {
        }

        public bool IsNotificationPermitted()
        {
            return true;
        }

        public void OpenAppSetting()
        {
        }

        public void Register(int delayTime, string message, string title)
        {
        }

        public void CancelAll()
        {
        }
    }
}
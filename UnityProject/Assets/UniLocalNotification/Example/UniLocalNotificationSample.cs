using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniLocalNotificationSample : MonoBehaviour {


    [SerializeField]
    private InputField timeDelayInput;
    [SerializeField]
    private Text statusText;
        

    private void Awake()
    {
        UniLocalNotification.Initialize();
    }

    public void Register()
    {
        int timeDelay;
        if (int.TryParse(timeDelayInput.text, out timeDelay))
        {
            UniLocalNotification.Register(timeDelay, "Message", "Title");
            statusText.text = string.Format("Notification Registered After {0} Sec", timeDelay);
        }
    }

    public void CheckIsLocalNotificaionPermitted()
    {
        bool isPermitted = UniLocalNotification.IsLocalNotificationPermitted();
        statusText.text = string.Format("Notification Permitted : {0}", isPermitted);
    }

    public void OpenAppSetting()
    {
        UniLocalNotification.OpenAppSetting();
    }

    public void CancelAll()
    {
        UniLocalNotification.CancelAll();
        statusText.text = "All Local Notification is Cancelled";
    }

}

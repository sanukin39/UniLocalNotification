extern "C"{
    void CleanIconBadge_();
    void OpenAppSetting_();
    bool IsNotificationPermitted_();
}

// Clean app icon badge
void CleanIconBadge_(){
    [UIApplication sharedApplication].applicationIconBadgeNumber = -1;
}

// Open app settings (more than ios8.0)
void OpenAppSetting_(){
    float iOSVersion = [[[UIDevice currentDevice] systemVersion] floatValue];
    if(iOSVersion >= 8.0){
        NSURL *url = [NSURL URLWithString:UIApplicationOpenSettingsURLString];
        [[UIApplication sharedApplication] openURL:url];
    }
}

// Check if notification is permitted by user (Always return true if version is less than 8.0)
bool IsNotificationPermitted_(){
    float iOSVersion = [[[UIDevice currentDevice] systemVersion] floatValue];
    if(iOSVersion < 8.0){
        return true;
    }
    UIUserNotificationSettings *settings = [[UIApplication sharedApplication] currentUserNotificationSettings];
    return settings.types != 0;
}

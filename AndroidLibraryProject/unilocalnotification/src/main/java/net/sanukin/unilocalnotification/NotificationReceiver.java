package net.sanukin.unilocalnotification;

import android.app.Notification;
import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Build;
import android.support.v4.app.NotificationCompat;

/**
 * Created by sanukiwataru on 2017/09/17.
 */

public class NotificationReceiver extends BroadcastReceiver {

    /**
     * Receiving notification event
     * @param context current context
     * @param intent received intent
     */
    @Override
    public void onReceive(Context context, Intent intent) {

        // get notification info
        String message = intent.getStringExtra("MESSAGE");
        String title = intent.getStringExtra("TITLE");
        int requestCode = intent.getIntExtra("REQUEST_CODE", 0);

        // create intent for taping notification
        final PackageManager pm=context.getPackageManager();
        Intent intentCustom = pm.getLaunchIntentForPackage(context.getPackageName());

        PendingIntent contentIntent = PendingIntent.getActivity(context, 0, intentCustom,
                PendingIntent.FLAG_UPDATE_CURRENT);

        // create icon bitmap
        ApplicationInfo applicationInfo = null;
        try {
            applicationInfo = pm.getApplicationInfo(context.getPackageName(),PackageManager.GET_META_DATA);
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
            return;
        }
        final int appIconResId=applicationInfo.icon;
        Bitmap largeIcon = BitmapFactory.decodeResource(context.getResources(), appIconResId);

        NotificationManager manager = (NotificationManager) context.getSystemService(Service.NOTIFICATION_SERVICE);

        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.O)
        {
            String channelId = "default";
            NotificationChannel channel = new NotificationChannel(channelId, title, NotificationManager.IMPORTANCE_DEFAULT);

            channel.setDescription(message);
            channel.enableVibration(true);
            channel.canShowBadge();
            channel.setLockscreenVisibility(Notification.VISIBILITY_PRIVATE);
            channel.setShowBadge(true);

            PendingIntent pendingIntent = PendingIntent.getActivity(context, 0, intent, PendingIntent.FLAG_ONE_SHOT);

            Notification notification = new Notification.Builder(context, channelId)
                    .setContentTitle(title)
                    .setContentText(message)
                    .setAutoCancel(true)
                    .setContentIntent(pendingIntent)
                    .setSmallIcon(context.getResources().getIdentifier("notification_icon", "drawable", context.getPackageName()))
                    .setLargeIcon(largeIcon)
                    .build();

            manager.notify(requestCode, notification);
        } else {
            // create notification builder
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context);
            builder.setContentIntent(contentIntent);

            // set notification info
            builder.setTicker("");
            builder.setContentTitle(title);
            builder.setContentText(message);

            // set icon
            builder.setLargeIcon(largeIcon);
            builder.setSmallIcon(context.getResources().getIdentifier("notification_icon", "drawable", context.getPackageName()));

            // fire now
            builder.setWhen(System.currentTimeMillis());

            // set device notification settings
            builder.setDefaults(Notification.DEFAULT_SOUND
                    | Notification.DEFAULT_VIBRATE
                    | Notification.DEFAULT_LIGHTS);

            // tap to cancel
            builder.setAutoCancel(true);

            // fire notification
            manager.notify(requestCode, builder.build());
        }
    }
}

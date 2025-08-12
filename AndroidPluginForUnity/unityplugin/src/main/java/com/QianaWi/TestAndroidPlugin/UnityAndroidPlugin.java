package com.QianaWi.TestAndroidPlugin;

import android.util.Log;
import com.unity3d.player.UnityPlayer;

public class UnityAndroidPlugin {

    private static final String TAG = "UnityAndroidPlugin";

    // Unity将调用此方法
    public void sendMessageToUnity(String message) {
        Log.d(TAG, "Received message from Unity: " + message);
        // 调用Unity中的GameObject上的方法,UnityReceiver为挂载脚本的GameObject,名称需要一致.
        UnityPlayer.UnitySendMessage("UnityReceiver", "ReceiveMessage", "这是一条来自android plugin的消息");
    }
}
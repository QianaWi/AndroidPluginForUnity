using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AndroidPluginCaller : MonoBehaviour
{
    public TextMeshProUGUI messageDisplay;
    private AndroidJavaObject androidPlugin;

    void Start()
    {
        // 确保在Android平台上运行
        if (Application.platform == RuntimePlatform.Android)
        {
            // 获取Android插件类的实例
            // 注意：这里的包名和类名必须与Android Studio中创建的完全一致
            androidPlugin = new AndroidJavaObject("com.QianaWi.TestAndroidPlugin.UnityAndroidPlugin");
        }
        else
        {
            Debug.LogWarning("Not running on Android platform. Android plugin calls will not work.");
        }
    }

    // 当按钮被点击时调用此方法
    public void OnCallPluginButtonClick()
    {
        if (androidPlugin != null)
        {
            // 调用Android插件中的sendMessageToUnity方法
            androidPlugin.Call("sendMessageToUnity", "Hello from Unity!");
            Debug.Log("Called Android plugin method sendMessageToUnity.");
        }
        else
        {
            Debug.LogError("Android plugin object is null. Make sure you are running on Android and the plugin is correctly set up.");
        }
    }

    // Android插件会通过UnityPlayer.UnitySendMessage调用此方法
    public void ReceiveMessage(string message)
    {
        if (messageDisplay != null)
        {
            messageDisplay.text = "Received from Android: " + message;
            Debug.Log("Received message from Android: " + message);
        }
        else
        {
            Debug.LogError("MessageDisplay TextMeshProUGUI is not assigned.");
        }
    }
}
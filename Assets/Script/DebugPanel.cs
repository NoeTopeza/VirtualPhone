using TMPro;
using UnityEngine;

namespace Script
{
    public class DebugPanel : MonoBehaviour
    { // Useful to debug even in the build
        //#if !UNITY_EDITOR
        static string myLog = "";
        private string output;
        private TextMeshProUGUI m_Text;

        private void Start()
        {
            m_Text = GetComponent<TextMeshProUGUI>();
            InvokeRepeating(nameof(ShowLog), 1, 1);
        }
     
        void OnEnable() => Application.logMessageReceived += Log;
        void OnDisable() => Application.logMessageReceived -= Log;

        public void Log(string logString, string stackTrace, LogType type)
        {
            output = logString;
            myLog = output + "\n" + myLog;
            if (myLog.Length > 5000)
                myLog = myLog.Substring(0, 4000);
        }
     
        void ShowLog()
        {
            m_Text.text = myLog;
        }
        //#endif
    }
}

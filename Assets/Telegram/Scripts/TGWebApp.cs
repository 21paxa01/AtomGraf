using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Networking;

namespace Telegram.WebApp
{
    public class TGWebApp : MonoBehaviour
    {
        [SerializeField] private string RestApiURL = "https://telegram.immortal-games.online/Games/rest/";
        private const string init = "init.php";
        private const string stats = "stats.php";
        private const string set = "set.php";
        public static TGWebApp instance;
        [DllImport("__Internal")]
        private static extern string GetUserData();
        [DllImport("__Internal")]
        private static extern string GetInitData();
        [DllImport("__Internal")]
        private static extern string GetHash();
        [DllImport("__Internal")]
        private static extern void FixAudio();
        [DllImport("__Internal")]
        private static extern void OpenURI(string url);
        public static void OpenURL(string url)
        {
#if UNITY_EDITOR
            Application.OpenURL(url);
#else
            OpenURI(url);
#endif
        }
        public UserData userData { get; private set; }

        void Awake()
        {
            if (instance)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
#if !UNITY_EDITOR
            string jsonUserData = GetUserData();
            userData = JsonUtility.FromJson<UserData>(jsonUserData);
#else
            userData = new UserData()
            {
                id = 1,
                is_bot = false,
                first_name = "pavlik",
                username = "@Vlad12234"
            };
#endif
            FixAudio();
            Debug.Log("Telegram Web App init");
        }
        public UnityWebRequestAsyncOperation Init()
        {
            string uri = Path.Combine(RestApiURL, init);
            WWWForm form = new WWWForm();
#if UNITY_EDITOR
            form.AddField("initData", "test");
#else
            form.AddField("initData", GetInitData());
            form.AddField("hash", GetHash());

#endif
            form.AddField("username", userData.username);
            form.AddField("id", userData.id.ToString());
            UnityWebRequest request = UnityWebRequest.Post(uri, form);
            return request.SendWebRequest();
        }
        public RateTable GetRateTable(int count)
        {
            string uri = Path.Combine(RestApiURL, stats, $"?count={count}&username={userData.username}");
            UnityWebRequest request = UnityWebRequest.Get(uri);
            var table = new RateTable(request.SendWebRequest());
            return table;
        }
        public UnityWebRequestAsyncOperation SetScore(int score)
        {
            string uri = Path.Combine(RestApiURL, set);
            WWWForm form = new WWWForm();
            form.AddField("username", userData.username);
            form.AddField("score", score);
            UnityWebRequest request = UnityWebRequest.Post(uri, form);
            return request.SendWebRequest();
        }
#if UNITY_EDITOR
        [MenuItem("MyMenu/Do Something")]
        public static void Test()
        {
            Debug.Log( Encode("test","key"));
        
        }
#endif
        public static string Encode(string text,string key)
        {

            string result = "";
            int keyLegth = key.Length;
            for (int i = 0; i < text.Length; i++)
            {
                char textChar = text[0];
                char keyChar = key[(i%keyLegth)];
                result += Convert.ToChar(Convert.ToByte(textChar)+Convert.ToByte(keyChar));
            }
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(result);
            return Convert.ToBase64String(plainTextBytes);
            
        }
    }
    [Serializable]
    public class UserInfo
    {
        public string rate;
        public string username;
        public string score;
    }

    [Serializable]
    public class RateTable : CustomYieldInstruction
    {
        public UserInfo[] top;
        public UserInfo[] down;
        public UserInfo my;
        private UnityWebRequestAsyncOperation request;
        public RateTable(UnityWebRequestAsyncOperation request)
        {
            this.request = request;
        }

        public override bool keepWaiting { get { 
        
                if(request == null)
                    return false;
                if(!request.isDone)
                    return true;
                Debug.Log(request.webRequest.downloadHandler.text);
                JsonUtility.FromJsonOverwrite(request.webRequest.downloadHandler.text,this);
                down = down.Reverse().ToArray();
                return false; 
            } 
        }
    }

    [Serializable]
    public class UserData
    {
        public long id;
        public bool is_bot;
        public string first_name;
        public string username;
    }

}

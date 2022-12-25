using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
                first_name = "pavlik"
            };
#endif
            Debug.Log("Telegram Web App init");
        }
        public UnityWebRequestAsyncOperation Init()
        {
            string uri = Path.Combine(RestApiURL, init);
            WWWForm form = new WWWForm();
            form.AddField("username", userData.first_name);
            UnityWebRequest request = UnityWebRequest.Post(uri, form);
            return request.SendWebRequest();
        }
        public RateTable GetRateTable(int count)
        {
            string uri = Path.Combine(RestApiURL, stats,$"?count={count}&username={userData.first_name}");
            UnityWebRequest request = UnityWebRequest.Get(uri);
            var table = new RateTable( request.SendWebRequest());
            return table;
        }
        public UnityWebRequestAsyncOperation SetScore(int score)
        {
            string uri = Path.Combine(RestApiURL, set);
            WWWForm form = new WWWForm();
            form.AddField("username", userData.first_name);
            form.AddField("score", score);
            UnityWebRequest request = UnityWebRequest.Post(uri, form);
            return request.SendWebRequest();
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
        public int id;
        public bool is_bot;
        public string first_name;
    }
}

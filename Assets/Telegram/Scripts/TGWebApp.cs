using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Networking;

namespace Telegram.WebApp
{
    public class TGWebApp : MonoBehaviour
    {
        //[SerializeField] 
        private const string RestApiURL = "https://telegram.immortal-games.online/Games/dev/rest/";
        private const string init = "tgauth.php";
        private const string stats = "stats.php";
        private const string set = "set.php";
        private const string start = "start.php";
        private const string end = "end.php";
        private const string step = "step.php";
        private const string memory = "mem.php";
        private const string bonus = "bonus.php";
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
            FixAudio();
#else
            userData = new UserData()
            {
                id = 1,
                is_bot = false,
                first_name = "pavlik",
                username = "@Vlad12234"
            };
#endif


            Debug.Log("Telegram Web App init");
        }
        public UnityWebRequestAsyncOperation Init()
        {
            string uri = Path.Combine(RestApiURL, init);
            Debug.Log(uri);
            WWWForm form = new WWWForm();
#if UNITY_EDITOR
            form.AddField("initData", "test");
#else
            form.AddField("initData", GetInitData());
#endif       
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
        /*
        public UnityWebRequestAsyncOperation SetScore(int score)
        {
            string uri = Path.Combine(RestApiURL, set);

            var data = new ScoreData() { score = score, username = userData.username };
            string json = JsonUtility.ToJson(data);
            json = Encode(json);
            UnityWebRequest request = UnityWebRequest.Post(uri, new WWWForm());
            byte[] jsonToSend = new UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            //request.SetRequestHeader("Content-Type", "application/json");
            return request.SendWebRequest();
        }*/

        public UnityWebRequestAsyncOperation StartGame()
        {
            string uri = Path.Combine(RestApiURL, start);
            var req = UnityWebRequest.Get(uri);
            return req.SendWebRequest();
        }

        public UnityWebRequestAsyncOperation EndGame(int score)
        {
            string uri = Path.Combine(RestApiURL, end);
            WWWForm form = new WWWForm();
            form.AddField("score", score);
            var req = UnityWebRequest.Post(uri, form);
            return req.SendWebRequest();
        }
        public UnityWebRequestAsyncOperation Step()
        {
            string uri = Path.Combine(RestApiURL, step);
            var req = UnityWebRequest.Get(uri);
            return req.SendWebRequest();
        }
        public UnityWebRequestAsyncOperation MemoryHack()
        {
            string uri = Path.Combine(RestApiURL, memory);
            var req = UnityWebRequest.Get(uri);
            return req.SendWebRequest();
        }
        public UnityWebRequestAsyncOperation Bonus()
        {
            string uri = Path.Combine(RestApiURL, bonus);
            var req = UnityWebRequest.Get(uri);
            return req.SendWebRequest();
        }
        public static string Encode(string message)
        {

            string password = "3sc3RLrpd17";

            // Create sha256 hash
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

            string encrypted = Cryptography.Crypto.EncryptString(message, key, iv);

            return encrypted;

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
    public class ScoreData
    {
        public string username;
        public int score;
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

        public override bool keepWaiting
        {
            get
            {

                if (request == null)
                    return false;
                if (!request.isDone)
                    return true;
                Debug.Log(request.webRequest.downloadHandler.text);
                JsonUtility.FromJsonOverwrite(request.webRequest.downloadHandler.text, this);
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
    public static class UnityWebRequestExtensions
    { 
        public static UnityWebRequestAsyncOperation LogRequest(this UnityWebRequestAsyncOperation operation)
        {
#if UNITY_EDITOR
            operation.ContinueWith((x) =>
            {
                Debug.Log("Result"+ operation.webRequest.result);
                Debug.Log("Text" + operation.webRequest.downloadHandler.text);
                Debug.Log("Code" + operation.webRequest.responseCode);

            });
#endif
            return operation;
        }
        public static UnityWebRequestAsyncOperation ContinueWith(this UnityWebRequestAsyncOperation operation,Action<UnityWebRequestAsyncOperation> action)
        {
            TGWebApp.instance.StartCoroutine(operation.Wait(action));
            return operation;
        }
        private static IEnumerator Wait(this UnityWebRequestAsyncOperation operation,Action<UnityWebRequestAsyncOperation> action)
        {
            yield return new WaitUntil( () =>operation.isDone);
            action?.Invoke(operation);
        }
    }
}

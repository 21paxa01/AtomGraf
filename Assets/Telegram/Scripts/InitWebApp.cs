using System.Collections;
using Telegram.WebApp;
using UnityEngine;

public class InitWebApp : MonoBehaviour
{
    public static bool isInit=false;
    public GameObject loadScreen;
    private IEnumerator Start()
    {
        if(isInit)
            yield break;
        loadScreen.gameObject.SetActive(true);
        var request = TGWebApp.instance.Init();
        yield return request;
        loadScreen.gameObject.SetActive(false);
        isInit=true;
    }
}
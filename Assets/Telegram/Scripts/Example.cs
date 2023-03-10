using System.Collections;
using System.Collections.Generic;
using Telegram.WebApp;
using UnityEngine;

public class Example : MonoBehaviour
{
    public TGWebApp app;
    IEnumerator Start()
    {
        var init = app.Init();
        yield return init;
        var setscore = app.EndGame(100);
        yield return setscore;
        
        Debug.Log(setscore.webRequest.downloadHandler.text);
        var RateTable = app.GetRateTable(5);
        yield return RateTable;
        foreach (var item in RateTable.top)
        {
            Debug.Log(item.username+" | "+item.score);
        }
        Debug.Log(RateTable.my.username + " | " + RateTable.my.score);
        foreach (var item in RateTable.down)
        {
            Debug.Log(item.username + " | " + item.score);
        }
    }
}

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
        var setscore = app.SetScore(100);
        yield return setscore;
        
        Debug.Log(setscore.webRequest.downloadHandler.text);
        var RateTable = app.GetRateTable(5);
        yield return RateTable;
        foreach (var item in RateTable.table)
        {
            Debug.Log(item.username+" | "+item.score);
        }
        }
}

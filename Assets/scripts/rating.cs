using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Telegram.WebApp;

public class rating : MonoBehaviour
{
    public TMP_Text name_1, name_2, name_3, name_4, name_5,score_1, score_2, score_3, score_4, score_5;
    public TGWebApp app;
    IEnumerator Start()
    {
        var init = app.Init();
        yield return init;
        var RateTable = app.GetRateTable(5);
        yield return RateTable;
        name_1.text = RateTable.table[0].username;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

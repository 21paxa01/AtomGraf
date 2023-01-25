using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Telegram.WebApp;

public class score : MonoBehaviour
{
    private static score instance;
    public TMP_Text score_text;
    public static int score_value { get { return score_hundreds + score_thousands; }  }
    private static int score_hundreds;
    private static int score_thousands;
    private static int hash;
    public static void AddScore(int score)
    {
        
        score_hundreds += score;
        if(score_hundreds>=1000)
        {
            score_hundreds -= 1000;
            
            score_thousands += 1000;
            TGWebApp.instance.Step();
        }
        hash = score_hundreds.GetHashCode();
        instance.TextUpdate();
    }
    void Start()
    {
        instance = this;
        score_hundreds = 0;
        score_thousands = 0;
        hash = score_hundreds.GetHashCode();
        TextUpdate();
        TGWebApp.instance.StartGame().LogRequest();
    }
    public static void GetBonus()
    {
        TGWebApp.instance.Bonus().ContinueWith((x) =>
        {
            if(x.webRequest.result==UnityEngine.Networking.UnityWebRequest.Result.Success)
            {

                score_thousands += 3000;
                instance.TextUpdate();
            }
        });
    }
    private void TextUpdate()
    {
        score_text.text = new string(' ', (6 - (score_value.ToString()).Length)).Replace(" ", "0") + score_value.ToString();
    }
    public static void CheckHash()
    {
        if (score_hundreds.GetHashCode() != hash)
        {
            TGWebApp.instance.MemoryHack();
        }
    }
}

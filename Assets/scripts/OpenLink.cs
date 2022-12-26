using System.Collections;
using System.Collections.Generic;
using Telegram.WebApp;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public int click;
    public GameObject menu;
    public void Open()
    {
        click++;
        if (click == 1)
        {
            StartCoroutine(DoubleClick());
        }    
    }
    public void Link()
    {
        TGWebApp.OpenURL("https://ruvds.com/");
    }
    IEnumerator DoubleClick()
    {
        yield return new WaitForSeconds(0.3f);
        if (click >= 2)
            menu.SetActive(true);
        click = 0;

    }
}

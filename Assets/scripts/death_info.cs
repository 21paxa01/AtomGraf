using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class death_info : MonoBehaviour
{
    public Sprite[] enemies_icons;
    public Image icon;
    public static int i;
    private int j;
    public TMP_Text title, info;
    public string[] kolobok_titles, izba_titles, yaga_titles, vodyanoi_titles, ciklop_titles, oborot_titles, koshzei_titles,pol_titles;
    public string[] kolobok_info, izba_info, yaga_info, vodyanoi_info, ciklop_info, oborot_info, koshzei_info,pol_info;
    public int test;
    public string[][] titles;
    public string[][] info_arr;
    IEnumerator Start()
    {
        titles = new string[8][];
        info_arr = new string[8][];
        titles[0] = kolobok_titles; titles[1] = izba_titles; titles[2] = yaga_titles; titles[3] = vodyanoi_titles; titles[4] = ciklop_titles; titles[5] = oborot_titles; titles[6] = koshzei_titles; titles[7]=pol_titles;
        info_arr[0]=kolobok_info; info_arr[1]=izba_info; info_arr[2]=yaga_info; info_arr[3]=vodyanoi_info; info_arr[4]=ciklop_info; info_arr[5]=oborot_info; info_arr[6] = koshzei_info; info_arr[7]=pol_info;
        update_icon();
        var scroe = Telegram.WebApp.TGWebApp.instance.SetScore(score.score_value);
        yield return scroe;
        Debug.Log(scroe.webRequest.downloadHandler.text);
    }

    void Update()
    {
    }
    public void update_icon()
    {
        icon.sprite = enemies_icons[i];
        j = Random.Range(0, 5);
        title.text = titles[i][j];
        info.text = info_arr[i][j];
    }
}

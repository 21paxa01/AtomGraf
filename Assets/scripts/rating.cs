using System.Collections;
using UnityEngine;
using Telegram.WebApp;
using System.Linq;

public class rating : MonoBehaviour
{
    public RateView viewPrefab;
    public GameObject separatorPrefab;
    public Transform content;
    public int count=5;
    public GameObject LoadScreen;

    private GameObject separatorTop;
    private GameObject separatorDown;
    private RateView[] top;
    private RateView[] down;
    private RateView my;
    private bool isInit = false;
    private void Init()
    {
        top = new RateView[count];
        for (int i = 0; i < count; i++)
        {
            top[i] = Instantiate(viewPrefab,content);
        }
        separatorTop =  Instantiate(separatorPrefab, content);
        my = Instantiate(viewPrefab, content);
        separatorDown = Instantiate(separatorPrefab, content);
        down = new RateView[count];
        for (int i = 0; i < count; i++)
        {
            down[i] = Instantiate(viewPrefab, content);
        }
        isInit = true;
        
    }
    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(Load());
    }
    private IEnumerator Load()
    {
        LoadScreen.gameObject.SetActive(true);
        if(!isInit)
            Init();
        var RateTable = TGWebApp.instance.GetRateTable(count);
        yield return RateTable;
        for (int i = 0; i < count; i++)
        {
            top[i].SetPlayerInfo(RateTable.top[i]);
        }
        for (int i = 0; i < count; i++)
        {
            down[i].SetPlayerInfo(RateTable.down[i]);
        }
        my.SetPlayerInfo(RateTable.my);
        if (Contains(RateTable.top,RateTable.my) || Contains(RateTable.down, RateTable.my))
        {
            separatorDown.SetActive(false);
            my.gameObject.SetActive(false);
        }
        LoadScreen.SetActive(false);
    }
    private bool Contains(UserInfo[] userInfoes,UserInfo user)
    {
        return userInfoes.First(x => x.rate == user.rate) != null;
    }
}

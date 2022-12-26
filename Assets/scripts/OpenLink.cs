using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public int click;
    public GameObject menu;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        Application.OpenURL("http://bit.ly/3VkxiJL");
    }
    IEnumerator DoubleClick()
    {
        yield return new WaitForSeconds(0.3f);
        if (click >= 2)
            menu.SetActive(true);
        click = 0;

    }
}

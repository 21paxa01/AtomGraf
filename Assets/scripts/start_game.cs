using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour
{
    public GameObject musicon,musicoff;
    public bool start_menu;
    void Start()
    {
        if (start_menu == true)
        {
            if (PlayerPrefs.GetInt("music") == -1)
            {
                musicoff.SetActive(false);
                musicon.SetActive(true);
            }
            else
            {
                musicoff.SetActive(true);
                musicon.SetActive(false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }
    public void SoundsOff()
    {
        PlayerPrefs.SetInt("music", -1);
    }
    public void SoundsOn()
    {
        PlayerPrefs.SetInt("music", 1);
    }
}

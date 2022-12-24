using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hero : MonoBehaviour
{
    public Scrollbar bar;
    public GameObject lightning, reload_circle, lightning_left, lightning_right,death_menu;
    public Image hp_bar;
    public float hp;
    public SpriteRenderer sprite;
    private bool reload,boster,shot_chek;
    public bool shield;
    public AudioSource shot, bost_shot, death, hit, rel0ad, heal, shielD, b0st,kick_sound;
    public bool kick;
    public Animator anim;
    public int click;
    public lightning script;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(-2.6f + bar.value * 5.2f, transform.position.y, transform.position.z);
        hp_bar.fillAmount = hp / 10;
        if (hp <= 0)
        {
            Time.timeScale = 0;
            if (PlayerPrefs.GetInt("music") != -1)
                death.Play();
            death_menu.SetActive(true);
        }
    }
    public void Shot()
    {
        if (boster==false&& kick==false)
        {
            click++;
            if(shot_chek==false)
                StartCoroutine(Click());
        }
    }
    IEnumerator Damage()
    {
        sprite.color = new Color(255, 0, 0);
        if (PlayerPrefs.GetInt("music") != -1)
            hit.Play();
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(255, 255, 255);
    }
    IEnumerator Click()
    {
        shot_chek = true;
        yield return new WaitForSeconds(0.2f);
        if (click == 1)
        {
            if (reload == false)
            {
                reload = true;
                if (PlayerPrefs.GetInt("music") != -1)
                    shot.Play();
                lightning.SetActive(true);
                script.reload();
                StartCoroutine(Reload());
            }
        }
        else
        {
            anim.SetBool("kick", true);
            yield return new WaitForSeconds(0.3f);
            if (PlayerPrefs.GetInt("music") != -1)
                kick_sound.Play();
            anim.SetBool("kick", false);
            shot_chek = false;
        }
        click = 0;

    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        reload = true;
        shot_chek = false;
        reload_circle.SetActive(true);
        if (PlayerPrefs.GetInt("music") != -1)
            rel0ad.Play();
        yield return new WaitForSeconds(1f);
        reload_circle.SetActive(false);
        reload = false;
        click = 0;
        shot_chek = false;
    }
    IEnumerator BOST()
    {
        yield return new WaitForSeconds(1f);
        lightning_left.SetActive(false);
        lightning_right.SetActive(false);
        lightning.SetActive(false);
        boster = false;
    }
    public void bost()
    {
        boster = true;
        StopCoroutine(Reload());
        reload_circle.SetActive(false);
        reload = false;
        lightning_left.SetActive(true);
        lightning_right.SetActive(true);
        lightning.SetActive(true);
        if (PlayerPrefs.GetInt("music") != -1)
            bost_shot.Play();
        StartCoroutine(BOST());
    }
    IEnumerator SHIELD()
    {
        yield return new WaitForSeconds(5f);
        shield = false;
    }
    public void Shield()
    {
        StartCoroutine(SHIELD());
    }

    public void damage()
    {
        StartCoroutine(Damage());
    }
}

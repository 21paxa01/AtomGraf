using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public bool test;
    public int icon_i;
    public Animator anim;
    public bool death;
    private bool sound_chek;
    public AudioSource hit,death_sound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyChek();
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (death == true)
        {
            anim.enabled = true;
            if(sound_chek==false)
            {
                sound_chek = true;
                if (PlayerPrefs.GetInt("music") != -1)
                    death_sound.Play();
            }
        }
        if(test==true)
            Destroy(gameObject);
    }
    void DestroyChek()
    {
        if (transform.position.y <= -5.6f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "hero")
        {
            if (other.gameObject.GetComponent<hero>().kick == false&&death==false)
            {
                if (other.gameObject.GetComponent<hero>().shield == false)
                    other.gameObject.GetComponent<hero>().hp -= 1;
                else
                    other.gameObject.GetComponent<hero>().hp -= 0.3334f;
                death_info.i = icon_i;
                other.gameObject.GetComponent<hero>().damage();
                if (PlayerPrefs.GetInt("music") != -1)
                    hit.Play();
            }
            else
                death = true;
        }
    }
}

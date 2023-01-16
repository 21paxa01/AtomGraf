using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public bool test;
    public bool pol;
    public int icon_i;
    public Animator anim;
    public bool death;
    private bool sound_chek,score_chek;
    public AudioSource hit,death_sound;
    public float damage;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyChek();

        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        rb.velocity = new Vector2(0, -speed);
        if (pol == false)
        {
            if (death == true)
            {
                anim.SetBool("death", true);
                if (sound_chek == false)
                {
                    sound_chek = true;
                    if (PlayerPrefs.GetInt("music") != -1)
                        death_sound.Play();
                }
            }
            if (test == true)
                Destroy(gameObject);
        }
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
            if (other.gameObject.GetComponent<hero>().kick == false && death == false)
            {
                if (other.gameObject.GetComponent<hero>().shield == false)
                    other.gameObject.GetComponent<hero>().hp -= damage;
                else
                    other.gameObject.GetComponent<hero>().hp -= damage/3;
                death_info.i = icon_i;
                other.gameObject.GetComponent<hero>().damage();
                if (PlayerPrefs.GetInt("music") != -1)
                    hit.Play();
            }
            else
            {
                death = true;
                if (score_chek == false)
                {
                    score_chek = true;
                    score.score_value += 75;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_background : MonoBehaviour
{
    public float speed;
    public bool forest, desert;
    public AudioSource music;
    public int i;
    public float  test;
    public bool first;
    public bool start;
    private bool locate_chek;
    void Start()
    {
        music.volume = 1;
        locate_chek = false;
    }

    // Update is called once per frame
    void Update()
    {
        test = transform.position.y/1.5f;
        tranport();
        if(locations.location_i==i|| test < 11.7f)
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        else
        {
            if (first == true)
                transform.position = new Vector3(transform.position.x, 11.7f * 1.5f, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, 28.033f * 1.5f, transform.position.z);
        }
        if (PlayerPrefs.GetInt("music") == -1)
            music.volume = 0;
    }
    void tranport()
    {
        if (test <= -13f)
            transform.position = new Vector3(transform.position.x, 19.09633f*1.5f, transform.position.z);
        if (locations.location_i!=i)
            music.volume = 0;
        else
            music.volume = 1;
    }
    public void UpdeteLocate()
    {
        if (locate_chek == false)
        {
            locate_chek = true;
            if (first == true)
                transform.position = new Vector3(transform.position.x, 11.7f * 1.5f, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, 28.033f * 1.5f, transform.position.z);
            start = false;
        }
        
    }
}

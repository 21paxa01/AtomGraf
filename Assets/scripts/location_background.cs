using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_background : MonoBehaviour
{
    public float speed;
    public bool forest, desert;
    public AudioSource music;
    public bool Forest, Desert, Sity;
    void Start()
    {
        music.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        tranport();
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (PlayerPrefs.GetInt("music") == -1)
            music.volume = 0;
    }
    void tranport()
    {
        if (transform.position.y <= -17.18f)
            transform.position = new Vector3(transform.position.x, 31.82f, transform.position.z);
        if (score.score_value >= 1000 && forest == true)
            music.volume = 0;
        if (score.score_value >= 2000 && desert == true)
            music.volume = 0;
    }
}

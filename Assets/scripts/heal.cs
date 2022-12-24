using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyChek();
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "hero")
        {
            if (other.gameObject.GetComponent<hero>().hp < 6)
                other.gameObject.GetComponent<hero>().hp += 5;
            else
                other.gameObject.GetComponent<hero>().hp = 10;
            if (PlayerPrefs.GetInt("music") != -1)
                other.gameObject.GetComponent<hero>().heal.Play();
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
}

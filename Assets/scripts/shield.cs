using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        DestroyChek();
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "hero")
        {
            other.gameObject.GetComponent<hero>().shield = true;
            other.gameObject.GetComponent<hero>().Shield();
            if (PlayerPrefs.GetInt("music") != -1)
                other.gameObject.GetComponent<hero>().shielD.Play();
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

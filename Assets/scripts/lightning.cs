using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

    }
    public void reload()
    {
        StartCoroutine(Reload());
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            if (other.GetComponent<enemy>().death == false)
            {
                score.AddScore(50);
                other.GetComponent<enemy>().death = true;
            }
        }

    }
}

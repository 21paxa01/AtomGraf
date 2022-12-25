using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    public int i;
    private SpriteRenderer sprite;
    public bool back;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (locations.location_i == i)
        {
            if (back == true)
                sprite.sortingOrder = -6;
            else
                sprite.sortingOrder = -5;
        }
        else
        {
            if (back == true)
                sprite.sortingOrder = -10;
            else
                sprite.sortingOrder = -9;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locations : MonoBehaviour
{
    public GameObject  desert1, sity1, desert2, sity2;
    public bool test;
    void Start()
    {

    }

    void Update()
    {
        if(score.score_value%3000>=1000 && score.score_value % 3000 < 2000)
        {
            desert1.SetActive(true);
            desert2.SetActive(true);

        }
        else if (score.score_value % 3000 >= 2000)
        {
            sity1.SetActive(true);
            sity2.SetActive(true);
        }
    }
}

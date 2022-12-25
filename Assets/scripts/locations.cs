using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locations : MonoBehaviour
{
    public GameObject forest1, forest2, desert1, sity1, desert2, sity2;
    public static int location_i;
    public bool test;
    void Start()
    {
        location_i = 0;
    }

    void Update()
    {
        if(score.score_value%3000>=1000 && score.score_value % 3000 < 2000)
        {
            //forest1.SetActive(false);
            //forest2.SetActive(false);
            desert1.SetActive(true);
           // desert1.GetComponent<location_background>().UpdeteLocate();
            desert2.SetActive(true);
           // desert2.GetComponent<location_background>().UpdeteLocate();
            //sity1.SetActive(false);
            //sity2.SetActive(false);
            location_i = 1;

        }
        else if (score.score_value % 3000 >= 2000)
        {
            sity1.SetActive(true);
           // sity1.GetComponent<location_background>().UpdeteLocate();
            sity2.SetActive(true);
            //sity2.GetComponent<location_background>().UpdeteLocate();
            forest1.SetActive(false);
            forest2.SetActive(false);
            location_i = 2;
        }
        else
        {
            forest1.SetActive(true);
            //forest1.GetComponent<location_background>().UpdeteLocate();
            forest2.SetActive(true);
            //forest2.GetComponent<location_background>().UpdeteLocate();
           // desert1.SetActive(false);
         //   desert2.SetActive(false);
            location_i = 0;

        }
    }
}

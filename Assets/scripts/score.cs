using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    public TMP_Text score_text;
    public static int score_value;
    void Start()
    {
        score_value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = new string(' ', (6 - (score_value.ToString()).Length)).Replace(" ", "0") + score_value.ToString();

    }
}

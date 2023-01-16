using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolobok_tap : MonoBehaviour
{
    private float distance;
    private spawn_enemies spawn;
    void Start()
    {
        spawn = GameObject.Find("spawn").GetComponent<spawn_enemies>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        distance= Vector2.Distance(transform.position, mousePosition);
        if (distance <= 0.3f&& Input.GetMouseButton(0))
            MenuOn();
    }
    private void MenuOn()
    {
        if (!PlayerPrefs.HasKey("kolobok_menu"))
        {
            PlayerPrefs.SetInt("kolobok_menu", 1);
            spawn.MenuOn();
        }
    }
}

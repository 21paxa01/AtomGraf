using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemies : MonoBehaviour
{
    public GameObject[] enemies_arr,bosters_arr;
    private float x;
    private int i,j;
    public bool spawn,test;
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(Spawn_bosters());
    }
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        while (spawn == true)
        {
            yield return new WaitForSeconds(2f);
            Enemy_position();
            Instantiate(enemies_arr[i], new Vector3(x, 5.7f, 0), transform.rotation);
        }
    }
    IEnumerator Spawn_bosters()
    {
        while (spawn == true)
        {
            yield return new WaitForSeconds(7f);
            Enemy_position();
            Instantiate(bosters_arr[j], new Vector3(x, 5.7f, 0), transform.rotation);
        }
    }
    void Enemy_position()
    {
        x = Random.Range(-2.4f, 2.4f);
        i = Random.Range(0, 6);
        j= Random.Range(0,3);
    }
}

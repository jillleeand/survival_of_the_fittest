﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    private Waypoints Wp;
    public float cycle;
    private Vector3 spawnPoint;
    public GameObject circ;
    private float rrange;

    public GameObject kluton;
    public Transform dropPoint;
    public float kluCountdown = 7f;


    // Start is called before the first frame update
    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Circles").GetComponent<Waypoints>();
        Wp.waypoints.Add(transform);
        StartCoroutine("Spawn");
    }


    private void Update()
    {
        kluCountdown -= Time.deltaTime;
        if (kluCountdown <= 0)
        {
            GameObject flo = Instantiate(kluton, dropPoint.position, transform.rotation);
            kluCountdown = 7f;
        }
    }

    IEnumerator Spawn()
    {

        for (; ; )
        {
            rrange = Random.Range(0.0f, 1.0f);
            Debug.Log(gameObject + "Circle probability");
            if (rrange > .85f)
            {
                spawnPoint = (Vector3)Random.insideUnitCircle * 3;
                GameObject cir = Instantiate(circ, (spawnPoint + transform.position), transform.rotation);
                Debug.Log("Circle");
            }

            yield return new WaitForSeconds(20f);
        }


    }



}
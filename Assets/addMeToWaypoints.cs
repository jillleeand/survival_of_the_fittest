using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addMeToWaypoints : MonoBehaviour
{

    private Waypoints Wp;
    public float cycle = 30f;
    private Vector3 spawnPoint;
    public GameObject triangle;
    private float rrange;



    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Triangles").GetComponent<Waypoints>();
        Wp.waypoints.Add(transform);
    }

    void Update()
    {
        cycle -= Time.deltaTime;
        if (cycle <= 0)
        {
            if (Wp.waypoints.Count >= 2)

            {
                Spawn();
            }

        }

    }

    void Spawn()
    {

        
        rrange = Random.Range(0.0f, 1.0f);
        if (rrange > .85f)
        {
            spawnPoint = (Vector3)Random.insideUnitCircle * 3;
            GameObject tri = Instantiate(triangle, (spawnPoint + transform.position), transform.rotation);
        }
        
        cycle = 15f;

        return;

    }
}

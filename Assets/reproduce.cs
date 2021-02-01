using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reproduce : MonoBehaviour
{
    public Waypoints Wp;
    public float cycle = 30f;
    public float rangeLimit;

    private Vector3 spawnPoint;
    private float rrange;
    private lifeCircle baby;

    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag(gameObject.tag + "s").GetComponent<Waypoints>();
        Wp.waypoints.Add(transform);
        baby = gameObject.GetComponent<lifeCircle>();
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
        if (rrange > rangeLimit)
        {
            lifeCircle clone;
            spawnPoint = (Vector3)Random.insideUnitCircle * 4;
            clone = Instantiate(baby, (spawnPoint + transform.position), transform.rotation);
        }

        cycle = 15f;

        return;

    }
}

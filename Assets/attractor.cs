using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{

    private lifeScout scoutLife;
    private Transform scoutT;
    private Waypoints Wp;
    private Vector3 dropPoint;
    private life myLife;

    public string myScout;
    public GameObject phyton;
    public float attractorSpeed = 5f;

    void Start()
    {
        scoutLife = GameObject.FindGameObjectWithTag(myScout).GetComponentInParent<lifeScout>();
        scoutT = GameObject.FindGameObjectWithTag(myScout).GetComponentInParent<Transform>();
        //Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        myLife = gameObject.GetComponentInParent<life>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag(myScout)) && (scoutLife.phytons > 0) && myLife.phase != "Satisfied") // && (Wp.waypoints.Count > 0)
        {
            //Wp.waypoints[0] = Wp.waypoints[1];
            //Wp.waypoints.Remove(Wp.waypoints[0]);
            other.GetComponentInParent<lifeScout>().phytons--;
            GameObject p = Instantiate(phyton, calculateMidpoint(), transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Phyton") && (myLife.phase != "Satisfied"))
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, other.transform.position, attractorSpeed * Time.deltaTime);
        }
    }

    Vector3 calculateMidpoint()
    {
        dropPoint = (transform.position + scoutT.position) / 2;
        return dropPoint;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{

    private lifeCircle scoutLife;
    private Transform scoutT;
    private Waypoints Wp;
    private Vector3 dropPoint;
    private lifeCircle myLife;

    public string myScout;
    public GameObject food;
    public float attractorSpeed = 5f;

    void Start()
    {
        //Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        myLife = gameObject.GetComponentInParent<lifeCircle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        scoutLife = GameObject.FindGameObjectWithTag(myScout).GetComponentInParent<lifeCircle>();
        if ((other.CompareTag(myScout)) && (scoutLife.foodStack.Count > 0) && myLife.phase != "Satisfied") // && (Wp.waypoints.Count > 0)
        {
            Debug.Log("Scout touched");
            //Wp.waypoints[0] = Wp.waypoints[1];
            //Wp.waypoints.Remove(Wp.waypoints[0]);
            scoutLife.foodStack.RemoveAt(0);
            GameObject p = Instantiate(food, calculateMidpoint(), transform.rotation);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.CompareTag(myScout)) && (scoutLife.foodStack.Count > 0) && myLife.phase != "Satisfied") // && (Wp.waypoints.Count > 0)
        {
            //Wp.waypoints[0] = Wp.waypoints[1];
            //Wp.waypoints.Remove(Wp.waypoints[0]);
            other.GetComponentInParent<lifeCircle>().foodStack.RemoveAt(0);
            GameObject p = Instantiate(food, calculateMidpoint(), transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Phyton") && (myLife.phase != "Satisfied"))
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, other.transform.position, attractorSpeed * Time.deltaTime);
        }
    }

    public Vector3 calculateMidpoint()
    {
        scoutT = GameObject.FindGameObjectWithTag(myScout).GetComponentInParent<Transform>();
        dropPoint = (transform.position + scoutT.position) / 2;
        return dropPoint;
    }

}

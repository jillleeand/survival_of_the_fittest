using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private Waypoints Wp;

    private int waypointIndex;
    private int foodCount;
    private Vector3 dropPoint;

    public GameObject phyton;

    private lifeCircle myLife;
    private lifeCircle otherLife;
    private List<float> myfs;

    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        myfs = GetComponent<lifeCircle>().foodStack;
        foodCount = GetComponent<lifeCircle>().foodStack.Count;
        StartCoroutine(keepItMoving());
    }

    IEnumerator keepItMoving()
    {
        for (; ; )
        {

            if (Wp.waypoints.Count > 0)
            {
                if (Wp.waypoints[0])
                {
                    transform.position = Vector2.MoveTowards(transform.position, Wp.waypoints[0].position, speed * Time.deltaTime);
                }
            }

            yield return null;
            //if (Vector2.Distance(transform.position, Wp.waypoints[waypointIndex].position) < 0.01f)
            //{
            //	Debug.Log(Wp.waypoints[waypointIndex].position);
            //	Debug.Log(transform.position);
            //	if (waypointIndex < Wp.waypoints.Length - 1)
            //	{
            //		waypointIndex++;
            //	}
            //	else
            //	{
            //		Destroy(gameObject);
            //	}
            //}
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Triangle") && (other.GetComponent<lifeCircle>().phase != "Satisfied") && (myfs.Count > 0))
        {
            otherLife = other.GetComponent<lifeCircle>();
            myfs.RemoveAt(0);
            if (otherLife.phase == "Needy")
            {
                otherLife.countdown = otherLife.satisfied;
                otherLife.phase = "Satisfied";
                if (Wp.waypoints[0] == other.transform)
                {
                    Wp.waypoints.Remove(Wp.waypoints[0]);
                }

            if (otherLife.phase == "Precarious")
            {
                otherLife.countdown = otherLife.needy;
                otherLife.phase = "Needy";
                if (Wp.waypoints[0] == other.transform)
                {
                    Wp.waypoints.Remove(Wp.waypoints[0]);
                }

                }
            }

        }
    }
}
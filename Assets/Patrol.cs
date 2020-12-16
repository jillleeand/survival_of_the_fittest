using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	public float speed;
	private Waypoints Wp;
	
	private int waypointIndex;
    private int phytons;

    public GameObject phyton;
	
    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        phytons = GetComponent<lifeScout>().phytons;
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

                else
                {
                    Wp.waypoints.Remove(Wp.waypoints[0]);
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


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Triangle") && ((other.GetComponent<life>().phase != "Satisfied")))
        {
            phytons--;
            GameObject p = Instantiate(phyton, transform.position, transform.rotation);
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolSquare : MonoBehaviour
{
    public float speed;
    private Waypoints Wp;

    private int waypointIndex;
    private lifeCircle lc;

    public GameObject tscout;

    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Triangles").GetComponent<Waypoints>();
        lc = GetComponent<lifeCircle>();
        StartCoroutine(keepItMoving());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((other.CompareTag("Triangle")) || (other.CompareTag("TScout")))
        {

            if (other.CompareTag("TScout"))
            {
                Debug.Log("TScout eaten");
                Transform nextscout = Wp.waypoints[Random.Range(0, Wp.waypoints.Count)];
                GameObject replacement = Instantiate(tscout, nextscout.position, nextscout.rotation);
                Destroy(nextscout.gameObject);
            }

            Destroy(other.gameObject);
            if (lc.phase == "Needy")
            {
                lc.countdown = 120f;
                lc.phase = "Satisfied";
            }

            else if (lc.phase == "Precarious")
            {
                lc.countdown = 80f;
                lc.phase = "Needy";
            }
        }
    }


    IEnumerator keepItMoving()
    {
        for (; ; )
        {
            if (lc.phase == "Satisfied")
            {
                yield return null;
            }

            else if (Wp.waypoints.Count > 0)
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

}

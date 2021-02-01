using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolSquare : MonoBehaviour
{
    public float speed;
    private Waypoints Wp;
    private lifeCircle lc;
    public GameObject home;
    private int count = 0;


    private void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Triangles").GetComponent<Waypoints>();
        lc = GetComponent<lifeCircle>();
        home = Instantiate(home, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Wp.waypoints.Count > 0 && lc.phase != "Satisfied")
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

        else if (lc.phase == "Satisfied")
        {
            transform.position = Vector2.MoveTowards(transform.position, home.transform.position, speed * Time.deltaTime);

        }

        count++;
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    if ((other.CompareTag("Triangle")) || (other.CompareTag("TScout")))
    //    {

    //        if (other.CompareTag("TScout"))
    //        {
    //            other.GetComponent<deathScout>().Death();
    //        }

    //        Wp.waypoints.Remove(other.transform);
    //        if (lc.phase == "Needy")
    //        {
    //            lc.countdown = lc.satisfied;
    //            lc.phase = "Satisfied";
    //        }

    //        else if (lc.phase == "Precarious")
    //        {
    //            lc.countdown = lc.needy;
    //            lc.phase = "Needy";
    //        }

    //        if (other)
    //        {
    //            Debug.Log(other);
    //            Destroy(other.gameObject);
    //        }
    //    }
    //}




}

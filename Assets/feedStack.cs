using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedStack : MonoBehaviour
{
    private Waypoints Wp;
    private lifeCircle l;
    private bool d;
    public bool scoutColliding = false;

    static lifeCircle scoutLife;


    // Start is called before the first frame update
    void Start()
    {
        Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        l = GetComponent<lifeCircle>();
        scoutLife = GameObject.FindGameObjectWithTag("TScout").GetComponent<lifeCircle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (l.phase != "Satisfied")
        {
            if (Wp.waypoints.Count == 0)
            {
                if (scoutLife.foodStack.Count >= 5)
                {
                    if (scoutColliding == false)
                    {
                        Wp.waypoints.Insert(0, transform);
                    }
                }
            }

            else
            {
                if (scoutLife.foodStack.Count >= 5)
                {
                    if ((Wp.waypoints[0] != transform) && (Wp.waypoints[0].CompareTag("Triangle") == false && scoutColliding == false))
                    {
                        Wp.waypoints.Insert(0, transform);
                    }
                }
            }
        }

        if ((l.phase == "Satisfied" && Wp.waypoints.Contains(transform))) // || ((Wp.waypoints.Contains(transform) && (Wp.waypoints[0] != transform))))
        {
            Wp.waypoints.Remove(gameObject.transform);
        }

        //if (l.phase == "Needy")
        //{
        //    yl.enabled = true;
        //    rl.enabled = false;
        //}

        //else if (l.phase == "Precarious")
        //{
        //    yl.enabled = false;
        //    rl.enabled = true;
        //}

        //else
        //{
        //    yl.enabled = false;
        //    rl.enabled = false;
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TScout"))
        {
            scoutColliding = true;
            if (Wp.waypoints.Count > 0 || other.GetComponent<lifeCircle>().foodStack.Count == 0)
            {
                if (Wp.waypoints[0] == gameObject.transform)
                {
                    Wp.waypoints.Remove(Wp.waypoints[0]);
                }
            }


        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("TScout"))
        {
            scoutColliding = true;
            if (Wp.waypoints.Count > 0)
            {
                if (Wp.waypoints[0] == transform)
                {
                    Wp.waypoints.Remove(Wp.waypoints[0]);
                }
            }
       

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TScout"))
        {
            scoutColliding = false;
        }

    }

    public void scoutChange()
    {
        scoutLife = GameObject.FindGameObjectWithTag("TScout").GetComponent<lifeCircle>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove : MonoBehaviour
{
    public float setCountdown;
    public float countdown;


    // Start is called before the first frame update
    void Start()
    {
        countdown = setCountdown;
    }


    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            if (tag == "TScout" || tag == "Player")
            {
                GetComponent<deathScout>().Death();
            }
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tag == "Theton")
        {
            if (other.CompareTag("Attractor") == false)
            {
                Destroy(gameObject);
            }
        }
    }
}

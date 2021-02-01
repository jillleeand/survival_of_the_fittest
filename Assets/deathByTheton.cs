using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathByTheton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Theton"))
        {
            if (tag == "TScout" || tag == "Player")
            {
                GetComponent<deathScout>().Death();
            }
            Destroy(gameObject);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class produceParticle : MonoBehaviour
{

    public GameObject particle;
    public Transform dropPoint;
    public float countdown;



    private void Start()
    {
        StartCoroutine("Make");
    }

    IEnumerator Make()
    {

        for (; ; )
        {
            Instantiate(particle, dropPoint.position, transform.rotation);
            yield return new WaitForSeconds(countdown);
        }


    }


}

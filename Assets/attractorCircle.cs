using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractorCircle : MonoBehaviour
{

    public float attractorSpeed = 5f;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Phyton"))
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, other.transform.position, attractorSpeed * Time.deltaTime);

        }

    }

}

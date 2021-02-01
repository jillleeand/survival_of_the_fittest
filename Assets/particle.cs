using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public float speed = 3f;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Generator").transform.position, speed * Time.deltaTime);
    }
}

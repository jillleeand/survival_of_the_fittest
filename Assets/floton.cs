using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floton : MonoBehaviour
{
    public float speed = 3f;
    private Transform gen;

    void Start()
    {
        gen = GameObject.FindGameObjectWithTag("Generator").transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, gen.position, speed * Time.deltaTime);
    }

}

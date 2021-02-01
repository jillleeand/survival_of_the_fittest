using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floton : MonoBehaviour
{
    public float speed = 3f;
    public GameObject particle;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Generator").transform.position, speed * Time.deltaTime);
    }

}

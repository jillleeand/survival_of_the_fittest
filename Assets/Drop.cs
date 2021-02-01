using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public GameObject phyton;
    public Transform dropPoint;

    private lifeCircle ct;

    // Start is called before the first frame update
    void Start()
    {
        ct = GetComponent<lifeCircle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))

        {
            DropPhyton();
        }

    }



    public void DropPhyton()
    {
        if (ct.foodStack.Count > 0)
        {
            GameObject p = Instantiate(phyton, dropPoint.position, dropPoint.rotation);
            ct.foodStack.RemoveAt(0);
        }
    }
}

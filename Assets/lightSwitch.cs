using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class lightSwitch : MonoBehaviour
{
    private Light2D yl;
    private Light2D rl;
    private lifeCircle l;

    // Start is called before the first frame update
    void Start()
    {
        yl = transform.Find("yellowLight").gameObject.GetComponent<Light2D>();
        rl = transform.Find("redLight").gameObject.GetComponent<Light2D>();
        l = GetComponent<lifeCircle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (l.phase == "Needy")
        {
            yl.enabled = true;
            rl.enabled = false;
        }

        else if (l.phase == "Precarious")
        {
            yl.enabled = false;
            rl.enabled = true;
        }

        else
        {
            yl.enabled = false;
            rl.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabCount : MonoBehaviour
{
    private GameObject me;
    private int count;
    private int hungerRemaining;
    private int lifeRemaining;
    private Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (me == null)
        {
            me = GameObject.FindGameObjectWithTag("Player");
        }

        count = me.GetComponent<lifeCircle>().foodStack.Count;
        hungerRemaining = (int)me.GetComponent<lifeCircle>().countdown;
        lifeRemaining = (int)me.GetComponent<remove>().countdown;

        displayText.text = "Stack: " + count.ToString() + " | Early expiration: " + hungerRemaining.ToString() + " | Life remaining: " + lifeRemaining.ToString();
    }
}

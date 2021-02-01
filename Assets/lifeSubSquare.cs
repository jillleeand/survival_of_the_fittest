using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeSubSquare : MonoBehaviour
{
	public lifeCircle myLife;

    private void Start()
    {
		myLife = GetComponent<lifeCircle>();
    }

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(myLife.food2.tag))
		{
			other.GetComponent<deathScout>().Death();

			if (myLife.phase == "Needy")
			{

				myLife.countdown = myLife.satisfied;
				myLife.phase = "Satisfied";

			}

			else if (myLife.phase == "Precarious")
			{
				myLife.countdown = myLife.needy;
				myLife.phase = "Needy";

			}

			else if (myLife.phase == "Satisfied")
			{
				myLife.foodStack.Add(myLife.foodPerish);
			}
		}
	}

}

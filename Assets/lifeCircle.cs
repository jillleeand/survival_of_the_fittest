using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeCircle : MonoBehaviour
{
	public float ShortTerm = 120f;
	public float countdown;
	public string phase = "Satisfied";


	void Start()
	{
		countdown = ShortTerm;
	}


    // Update is called once per frame
    void Update()
    {
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			Destroy(gameObject);
		}

		else if (countdown <= 40f)
		{
			phase = "Precarious";
		}


		else if (countdown <= 80f)
		{
			phase = "Needy";
		}




	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Triangle"))
		{
			if (phase == "Needy")
            {
				countdown = 120f;
				phase = "Satisfied";
			}

			else if (phase == "Precarious")
			{
				countdown = 80f;
			}



		}
	}
}

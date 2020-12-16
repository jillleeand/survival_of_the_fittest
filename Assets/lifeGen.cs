using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeGen : MonoBehaviour
{
	public float ShortTerm = 120f;
	public float countdown;
	public string phase = "Satisfied";
	public float lifetime = 240f;

	void Start()
	{
		countdown = ShortTerm;
	}


	// Update is called once per frame
	void Update()
	{
		countdown -= Time.deltaTime;
		lifetime -= Time.deltaTime;

		if ((countdown <= 0f) || (lifetime <= 0f))
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

		else
        {
			phase = "Satisfied";
        }

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Kluton"))
		{
			countdown += 5f;
			Destroy(other.gameObject);

			if (countdown >= 120f)
            {
				countdown = 120f;
            }
		}
	}
}

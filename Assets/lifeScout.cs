using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeScout : MonoBehaviour
{
	public float ShortTerm = 75f;
	public float countdown;
	public string phase = "Satisfied";
	public int phytons = 0;

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

		else if (countdown <= 45f)
		{
			if (phytons > 0)
			{
				phytons = phytons - 1;
				countdown = 60f;
				phase = "Needy";
			}

			else
			{
				phase = "Precarious";
			}
		}


		else if (countdown <= 60f)
		{

            if (phytons > 0)
            {
				phytons = phytons - 1;
				countdown = 75f;
				phase = "Satisfied";

			}

			else
            {
				phase = "Needy";

			}
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Phyton"))
		{
			Destroy(other.gameObject);

			if (phase == "Satisfied")
            {
				phytons++;
            }

			else if (phase == "Needy")
            {
				countdown = 75f;
				phase = "Satisfied";
			}

			else if (phase == "Precarious")
			{
				countdown = 60f;
				phase = "Needy";
			}

		}
	}
}

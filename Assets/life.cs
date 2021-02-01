using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class life : MonoBehaviour
{
	public string phase = "Satisfied";
	public int phytons = 0;
	public GameObject floton;
	public float floCountdown = 7f;

	public float satisfied = 75f;
	public float needy = 50f;
	public float precarious = 25f;


	public float lifetime;
	public bool d = false;


	private Waypoints Wp;
	private lifeScout scoutLife;
	private Transform dropPoint;
	public float countdown;


	void Start()
    {
		Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
		scoutLife = GameObject.FindGameObjectWithTag("TScout").GetComponentInParent<lifeScout>();
		dropPoint = transform.Find("dropPoint");
		lifetime = 150f;
		countdown = satisfied;
	}

	// Update is called once per frame
	void Update()
	{
		countdown -= Time.deltaTime;
		floCountdown -= Time.deltaTime;
		lifetime -= Time.deltaTime;


		if (countdown <= 0f || lifetime <= 0f)
		{
			Destroy(gameObject);
		}

		if (countdown <= needy)
		{
			d = (gameObject.CompareTag("Triangle")) && (scoutLife.phytons > 5) && (Wp.waypoints.Count > 0) && (Wp.waypoints[0] != gameObject.transform) && (Wp.waypoints[0].CompareTag("Triangle") == false);

			if (phytons > 0)
			{
				phytons = phytons - 1;
				if (countdown <= precarious)
				{
					countdown = needy;
					phase = "Needy";
				}

				else
				{
					countdown = satisfied;
					phase = "Satisfied";
					floCountdown = 7f;
					if (Wp.waypoints.Count > 0)
					{
                        if (Wp.waypoints[0] == gameObject.transform)
                        {
                            Wp.waypoints.Remove(Wp.waypoints[0]);
                        }
                    }
				}
			}

			else
            {
				if (countdown <= precarious)
				{
					phase = "Precarious";
				}

				else
				{
					phase = "Needy";
				}
			}
			return;
		}

		if (gameObject.CompareTag("Triangle"))
		{
			if (floCountdown <= 0)
			{
				GameObject flo = Instantiate(floton, dropPoint.position, transform.rotation);
				floCountdown = 7f;
			}
		}
	}

	//   IEnumerator Fade()
	//   {
	//       for (float ft = 1f; ft >= 0; ft -= 0.1f)
	//       {
	//		Debug.Log("Fade");
	//           Color c = GetComponentInChildren<Renderer>().material.color;
	//           c.a = ft;
	//           c = GetComponentInChildren<Renderer>().material.color;
	//		yield return new WaitForSeconds(.1f);
	//	}
	//}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Phyton"))
		{
			Destroy(other.gameObject);

			if (phase == "Needy")
			{
				countdown = satisfied;
				phase = "Satisfied";
				if (gameObject.CompareTag("Triangle") && (Wp.waypoints[0] == gameObject.transform))
				{
					Wp.waypoints.Remove(Wp.waypoints[0]);
				}

			}

			else if (phase == "Precarious")
			{
				countdown = needy;
				phase = "Needy";

				if (gameObject.CompareTag("Triangle") && (Wp.waypoints[0] == gameObject.transform))
				{
					Wp.waypoints.Remove(Wp.waypoints[0]);
				}

			}

			else if (phase == "Satisfied")
			{
				phytons++;
			}
		}
	}


}


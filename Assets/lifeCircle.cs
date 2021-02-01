using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeCircle : MonoBehaviour
{

	public GameObject food;
	public GameObject food2;

	public string phase = "Satisfied";
	public float satisfied;
	public float needy;
	public float precarious;

	public bool d = false;

	private Waypoints Wp;
	private lifeCircle scoutLife;
	public float countdown;

	private deathScout deathScript;


	public List<float> foodStack;

	public float foodPerish;


	void Start()
	{
		Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
		scoutLife = GameObject.FindGameObjectWithTag("TScout").GetComponentInParent<lifeCircle>();
		countdown = satisfied;
	}

	// Update is called once per frame
	void Update()
	{
		countdown -= Time.deltaTime;

		if (countdown <= 0f)
		{
			if (tag == "TScout" || tag == "Player")
			{
				GetComponent<deathScout>().Death();
			}
			Destroy(gameObject);
		}


		//if (foodCount > 0)
		//      {
		//	//foodPerish -= Time.deltaTime;

		if (foodStack.Count > 0)
		{
			for (int i = 0; i < foodStack.Count; i++)
			{
				foodStack[i] -= Time.deltaTime;
				if (foodStack[i] <= 0)
				{
					if (countdown <= precarious)
					{
						countdown = needy;
						phase = "Needy";
					}

					else
					{
						countdown = satisfied;
						phase = "Satisfied";
					}

				}
			}

			foodStack.RemoveAll(list_item => list_item <= 0);
			//                 if (foodPerish <= 0)
			//         {
			//	foodCount--;
			//	countdown = satisfied;
			//	foodPerish = 10f;

		}

		else if (countdown <= precarious)
		{
			phase = "Precarious";
		}

		else if (countdown <= needy)
        {
			phase = "Needy";
        }

		else
        {
			phase = "Satisfied";
        }
		//	if (foodCount > 0)
		//	{
		//		foodCount--;
		//		foodPerish = 10f;

		//		if (countdown <= precarious)
		//		{
		//			countdown = needy;
		//			phase = "Needy";
		//		}

		//		else
		//		{
		//			countdown = satisfied;
		//			phase = "Satisfied";
		//		}
		//	}

		//	else
		//	{
		//		if (countdown <= precarious)
		//		{
		//			phase = "Precarious";
		//		}

		//		else
		//		{
		//			phase = "Needy";
		//		}
		//	}
		//	return;
		//}

		//}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(food.tag))
		{
			Destroy(other.gameObject);

			if (countdown <= precarious)
			{

				countdown = needy;
				phase = "Needy";

			}

			else if (countdown <= needy)
			{
				countdown = satisfied;
				phase = "Satisfied";

			}

			else
			{
				foodStack.Add(foodPerish);
			}
		}
	}

}
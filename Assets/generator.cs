using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{

	public int flotons;

	public GameObject phyton;
	private float radius;
	private Vector3 randomPos;
	public float countdownAssign;

	public float makeCountdown;
	public float eatCountdown = 1f;
	private Waypoints Wp;


	void Start()
	{
		radius = GetComponent<SpriteRenderer>().bounds.size.y / 2f;
		Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
	}

	private void Update()
	{
		if (flotons > 0)
        {
			eatCountdown -= Time.deltaTime;
        }

		makeCountdown -= Time.deltaTime + ((float)flotons / 60);
		if (makeCountdown <= 0)
		{
			Make();
			makeCountdown = countdownAssign;
		}

		if (eatCountdown <= 0)
        {
			flotons -= 1;
			eatCountdown = 1f;
        }	
	}

	void Make()
	{
		randomPos = (Vector3)Random.insideUnitCircle * .5f;
		float A = randomPos[0];
		float B = randomPos[1];

		float C = Mathf.Sqrt((A * A) + (B * B)); // C = sqrt(A^2 + B^2)

		// We now know C
		float distance = C + radius;

		// distance/C == x/A == y/B

		float x = (distance / C) * A;
		float y = (distance / C) * B;

		randomPos += new Vector3(x, y, 0) + transform.position;

		GameObject food = Instantiate(phyton, randomPos, transform.rotation);

		Wp.waypoints.Add(food.transform);

	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Floton"))
		{
			Destroy(other.gameObject);
			flotons++;
		}
	}

}

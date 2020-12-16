using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makePhytons : MonoBehaviour
{
	//public GameObject phyton;
	//private float radius;
 //   private Vector3 randomPos;
	//private float makeCountdown = 3f;
	//private Waypoints Wp;


 //   void Start()
	//{
	//	radius = GetComponent<SpriteRenderer>().bounds.size.y / 2f;
	//	Wp = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
 //   }


 //   private void Update()
 //   {
	//	if (flotons >= 0)
 //       {
	//		makeCountdown -= Time.deltaTime;
	//		if (makeCountdown <= 0)
	//		{
	//			Make();
	//			makeCountdown = 3f;
	//		}
 //       }
			
 //   }

 //   void Make()
 //   {
	//	randomPos = (Vector3)Random.insideUnitCircle * .5f;
	//	float A = randomPos[0];
	//	float B = randomPos[1];

	//	float C = Mathf.Sqrt((A * A) + (B * B)); // C = sqrt(A^2 + B^2)

	//	// We now know C
	//	float distance = C + radius;

	//	// distance/C == x/A == y/B

	//	float x = (distance / C) * A;
	//	float y = (distance / C) * B;

	//	randomPos += new Vector3(x, y, 0) + transform.position;

	//	GameObject food = Instantiate(phyton, randomPos, transform.rotation);

	//	Wp.waypoints.Add(food.transform); 

//	}

}
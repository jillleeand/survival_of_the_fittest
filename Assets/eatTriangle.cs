using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatTriangle : MonoBehaviour
{
	private lifeScout ls;
	private Waypoints Wp;

	void Start()
	{
		ls = GetComponent<lifeScout>();
	}


	//private void OnTriggerEnter2D(Collider2D other)
	//{

	//	if ((other.CompareTag("Triangle")) || (other.CompareTag("TScout")))
	//	{

	//		if (other.CompareTag("TScout"))
 //           {


 //           }

	//		Destroy(other.gameObject);

	//		if (ls.phase == "Needy")
	//		{
	//			ls.countdown = 120f;
	//			ls.phase = "Satisfied";
	//		}

	//		else if (ls.phase == "Precarious")
	//		{
	//			ls.countdown = 80f;
	//			ls.phase = "Needy";
	//		}
	//	}
	//}
}

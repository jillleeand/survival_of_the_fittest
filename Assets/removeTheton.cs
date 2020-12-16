using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeTheton : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag("Attractor") == false)
		{
			Destroy(gameObject);
		}

	}
}

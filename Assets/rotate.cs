using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

	private float randomNumber;

    // Update is called once per frame
    void Start()
    {
		randomNumber = Random.Range(-1f, 1f);
		StartCoroutine(Rotate());
	}


	IEnumerator Rotate()
	{
		for (; ; )
		{
			transform.Rotate(0, 0, randomNumber);
			yield return null;
		}
	}


}

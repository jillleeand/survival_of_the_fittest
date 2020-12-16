using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

	public Transform firePoint;
	public GameObject theton;
	
	public float thetonForce = 20f;

	
    // Update is called once per frame
    void Update()
    {
    	if(Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    }
	
	void Shoot()
	{
		GameObject bullet = Instantiate(theton, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * thetonForce, ForceMode2D.Impulse);
	}

}

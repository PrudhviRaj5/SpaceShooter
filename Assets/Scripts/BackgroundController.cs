using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour 
{
	public GameObject background;
	public Transform shotspawn;
	private float fireRate = 50;
	private float nextFire=-0.1f;
	
	void Update()
	{
		if (Time.time > nextFire) 
		{
			Instantiate (background, shotspawn.position, shotspawn.rotation);
			nextFire = Time.time + fireRate;
		}
	}
}

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	private float speedX;
	private float speedY = 0.0f;
	public float speedZ;

	public GameObject shot;
	public Transform shotspawn;
	public float fireRate;
	private float nextFire=-0.1f;

	
	void Start ()
	{
		if (shotspawn.position.x < 0.0f) 
		{
			speedX = -11.0f / speedZ;
		}
		if (shotspawn.position.x > 0.0f) 
		{
			speedX = 11.0f / speedZ;
		}
		rigidbody.velocity = new Vector3 (speedX, speedY, speedZ);

	}

	void Update()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotspawn.position, shotspawn.rotation);
			audio.Play ();
		}
	}

}

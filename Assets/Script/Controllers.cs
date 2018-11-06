using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controllers : NetworkBehaviour {

	//Bullet
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	private bool _CDBullet;
	private float TimeCDBullet;

	//camera
	public float VerticalSpeed;
	float v;
	public Camera FPS_camera;

	// Use this for initialization
	void Start () {
		_CDBullet = true;
	}
	
	// Update is called once per frame
	void Update () {
		TimerComparation();

		v = VerticalSpeed * Input.GetAxis("Mouse Y");
		FPS_camera.transform.Rotate(-v, 0, 0);

		if (Input.GetMouseButton(0))
		{
			if (_CDBullet){
				Fire();
			}			
		}
	}

	void Fire()
	{
		Vector3 position = new Vector3(0, 0, 1);
		// Create the Bullet from the Bullet Prefab
		
			GameObject bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

			// Add velocity to the bullet
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;

			// Destroy the bullet after 2 seconds
			Destroy(bullet, 8.0f);

		//CDContoller
		TimeCDBullet = Time.time + 1;
		_CDBullet = false;
	}

	private void TimerComparation()
	{
		float timeNow = Time.time;
		Debug.Log("Time" + timeNow);

		if (timeNow >= TimeCDBullet)
		{
			_CDBullet = true;
		}
	}
}

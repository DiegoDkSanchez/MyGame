using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Habilities : NetworkBehaviour
{

	public Text txtE;
	public Text txtCntrol;

	public GameObject BaseRocks;
	public GameObject WallRocks;
	public GameObject RockShoot;
	public GameObject PositionWallRocks;
	public bool CDBaseRock;
	public bool CDWallRock;
	public bool CDRockShoot;
	public float TimeCDBaseRock;
	public float TimeCDWallRock;
	public float TimeCDRockShoot;
	private Vector3 _positionBaseRock;
	private Vector3 _positionWallRock;
	// Use this for initialization
	void Start () {
		_positionBaseRock = new Vector3();
		CDBaseRock = true;
	}
	
	// Update is called once per frame
	void Update () {

		_positionBaseRock = transform.position;
		_positionBaseRock.y -= 10;
		_positionWallRock = PositionWallRocks.transform.position;
		_positionWallRock.y -= 0.5f;

		TimerComparation();

		if(Healt.life <= 0)
		{
			CDWallRock = false;
			CDBaseRock = false;
		}

		//Lisent Controls

		// "Ctrl"
		if (Input.GetKey(KeyCode.LeftControl))
		{
			if (CDBaseRock)
			{
				Instantiate(BaseRocks, _positionBaseRock, Quaternion.identity);
				TimeCDBaseRock = Time.time + 10;
				//TimeCDBaseRock = Time.time + 1;
				CDBaseRock = false;
				txtCntrol.color = new Color32(244, 244, 244, 77);
			}
		}

		// "E"
		if (Input.GetKey(KeyCode.E))
		{
			if (CDWallRock)
			{
				Instantiate(WallRocks, _positionWallRock, PositionWallRocks.transform.rotation);
				TimeCDWallRock = Time.time + 8;
				//TimeCDWallRock = Time.time + 1;
				CDWallRock = false;
				txtE.color = new Color32(244, 244, 244, 77);
			}
		}

		// "Click Izquierdo"
		if (Input.GetMouseButton(0))
		{
			if (CDRockShoot)
			{
				
				//Launch(,5f);
			}
		}

	}

	private void TimerComparation()
	{
		float timeNow = Time.time;
		Debug.Log("Time" + timeNow);
		if (timeNow >= TimeCDBaseRock)
		{
			CDBaseRock = true;
			txtCntrol.color = new Color(244f,244f,244f, 255f);
		}

		if (timeNow >= TimeCDWallRock)
		{
			CDWallRock = true;
			txtE.color = new Color(244f, 244f, 244f, 255f);
		}
		
	}

	public void Launch(Rigidbody roca, float speed)
	{
		Rigidbody accion = Instantiate(roca, transform.position, transform.rotation) as Rigidbody;
		accion.AddForce(transform.forward * speed);
	}
}

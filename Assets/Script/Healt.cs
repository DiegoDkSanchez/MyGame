using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Healt : NetworkBehaviour
{

	public GameObject DeadPosition;

	public static int life = 100;
	public Text txtlife;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//LifeControls
		txtlife.text = life + "";
		if (life <= 0)
		{
			transform.position = DeadPosition.transform.position;
			
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "DustStorm")
		{
			life = 0;
			
		}
		
	}
}

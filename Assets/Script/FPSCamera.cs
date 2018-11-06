using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSCamera : NetworkBehaviour
{

	public Camera FPS_camera;

	public float VerticalSpeed;
	public float HorizontalSpeed;
	public float SpeedWalk;

	float h;
	float v;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		h = HorizontalSpeed * Input.GetAxis("Mouse X");
		v = VerticalSpeed * Input.GetAxis("Mouse Y");

		transform.Rotate(0, h, 0);
		FPS_camera.transform.Rotate(-v, 0, 0);

		if (Input.GetKey(KeyCode.W)){
			transform.Translate(0, 0, SpeedWalk);

		}else if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(0, 0, -SpeedWalk);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(-SpeedWalk, 0, 0);
		}else if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(SpeedWalk, 0, 0);
		}

	}
}

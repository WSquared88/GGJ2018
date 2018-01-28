using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwivel : MonoBehaviour
{
	[Range(.1f, 5)]
	public float rotateSpeed = .75f;
	[Range(.1f, 5)]
	public float moveSpeed = .75f;
	float time = 0;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime * rotateSpeed;
		transform.Rotate(Vector3.up, Mathf.Cos(time) * moveSpeed, Space.World);
	}
}

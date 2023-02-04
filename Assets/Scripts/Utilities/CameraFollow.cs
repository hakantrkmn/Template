using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
	public Transform target;

	private float zOffset;
	private float yOffset;

	public float lerpSpeed = 3f;

	public Vector3 mouseStartPos;
	private void Start()
	{
	}

	public float timer;
	public float angle;
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			mouseStartPos = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			timer += Time.deltaTime;
			var direction = mouseStartPos - Input.mousePosition;
			var temp = new Vector3(0, direction.x,0);
			if (timer>.1f)
			{
				mouseStartPos = Input.mousePosition;
			}

			if (Mathf.Abs(direction.x)>1)
			{
				transform.RotateAround (target.position, temp.normalized, direction.magnitude*angle);

			}
			if (transform.position.y>10&& transform.position.y<25)
			{
				if (direction.y<-1)
				{
					var dir = target.position - transform.position;
					transform.position += dir.normalized * 3 * Time.deltaTime;
				}
				else if(direction.y>1)
				{
					var dir = target.position - transform.position;
					transform.position -= dir.normalized * 3 * Time.deltaTime;
				}
			}
			else if (transform.position.y<10)
			{
				 if(direction.y>1)
				{
					var dir = target.position - transform.position;
					transform.position -= dir.normalized * 3 * Time.deltaTime;
				}
			}
			else if (transform.position.y>25)
			{
				if (direction.y<-1)
				{
					var dir = target.position - transform.position;
					transform.position += dir.normalized * 3 * Time.deltaTime;
				}
			}

			
			
		}
		

	}
}

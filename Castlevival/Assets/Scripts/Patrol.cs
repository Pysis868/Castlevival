using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {
	
	public int nextWaypoint;
	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public GameObject point4;
	public GameObject alertPoint;
	public GameObject model;
	public float speed = 0.1f;
	public float tolerance = 0.2f;
	float x;
	float z;
	private bool isIdle;
	private Shapeshift playerForm;
	// Use this for initialization
	void Start ()
	{
		nextWaypoint = 1;
		isIdle = true;
		playerForm = GameObject.FindGameObjectWithTag ("Player").GetComponent ("Shapeshift") as Shapeshift;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isIdle)
		{
			switch (nextWaypoint)
			{
			case 1:
				MoveToWaypoint (point1);
				break;
			case 2:
				MoveToWaypoint (point2);
				break;
			case 3:
				MoveToWaypoint (point3);
				break;
			case 4:
				MoveToWaypoint (point4);
				break;
			}
		}
		else
		{
			MoveToWaypoint(alertPoint);
		}
		
	}
	
	void OnTriggerEnter(Collider col) {
		//If we see the player
		if(col.gameObject.CompareTag ("Player")) {
			//If the player isn't a bat
			if(!playerForm.shifted) {
				//If the player is in our line of sight
				isIdle = false;
			}
		}
	}
	
	void MoveToWaypoint(GameObject point)
	{
		transform.LookAt (point.transform);
		rigidbody.velocity = speed * transform.forward;
		if(Vector3.Distance (transform.position, point.transform.position) < tolerance) {
			CycleWaypoint(point);
		}
	}
	
	void OnCollisionEnter(Collision col) {
		if(col.collider.gameObject.CompareTag ("Player")) {
			isIdle = true;
		}
	}
	
	void CycleWaypoint (GameObject point)
	{
		if (point.Equals(point1))
		{
			nextWaypoint = 2;
		}
		if (point.Equals(point2))
		{
			nextWaypoint = 3;
		}
		if (point.Equals(point3))
		{
			nextWaypoint = 4;
		}
		if (point.Equals(point4))
		{
			nextWaypoint = 1;
		}
		if (point.Equals(alertPoint))
		{
			isIdle = true;
		}
	}
}

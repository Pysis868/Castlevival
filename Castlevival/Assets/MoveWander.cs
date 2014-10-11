using UnityEngine;
using System.Collections;

public class MoveWander : MonoBehaviour {

	public float movementSpeed = 10;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward * movementSpeed;
		InvokeRepeating("RandomScurry", 0f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		
	}
	
	void RandomScurry() {
		int action = Random.Range(0, 100);
		
		if(action < 20) {
			StartMoving();
		} else if (action < 50) {
			StopMoving();
		} else {
			ChangeDirection();
		}
	}
	
	void StartMoving() {
		rigidbody.velocity = transform.forward * movementSpeed;
	}
	
	void StopMoving() {
		rigidbody.velocity *= 0;
	}
	
	//Pick a new random direction
	void ChangeDirection() {
		transform.Rotate (0, Random.Range (0, 359), 0);
		rigidbody.velocity = transform.forward * rigidbody.velocity.magnitude;
	}
}

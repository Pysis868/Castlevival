using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	float up = 0.0f;
	float right = 0.0f;
	float posX = 0.0f;
	float posY = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey("a"))
		{
			right = -1.0f;
		}
		if (Input.GetKey("s"))
		{
			up = -1.0f;
		}
		if (Input.GetKey("w"))
		{
			up = 1.0f;
		}
		if (Input.GetKey("d"))
		{
			right = 1.0f;
		}
		posX = transform.position.x;
		posY = transform.position.y;
		transform.position.Set(posX + right, posY + up, 1.0f);
	}
}

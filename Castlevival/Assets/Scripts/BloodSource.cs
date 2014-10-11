using UnityEngine;
using System.Collections;

public class BloodSource : MonoBehaviour {

	public float amount = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (amount == 0) {
			Destroy(gameObject.GetComponent("Rat"));
			Destroy(gameObject.collider);
			Destroy(gameObject, 2f);
			Destroy(this);
		}
	}
	
	public float Drain() {
		float drainedAmount = amount;
		amount = 0;
		return drainedAmount;
	}
}

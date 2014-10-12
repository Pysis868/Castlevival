using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string destination;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag ("Player")) {
			Application.LoadLevel (destination);
		}
	}
	
}

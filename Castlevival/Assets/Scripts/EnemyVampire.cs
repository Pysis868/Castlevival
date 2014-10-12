using UnityEngine;
using System.Collections;

public class EnemyVampire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.tag = "Victim";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDestroy() {
		Application.LoadLevel ("Win");
	}
}

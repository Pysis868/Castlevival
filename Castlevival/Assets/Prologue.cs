using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class Prologue : MonoBehaviour {
	
	TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh>();
		textMesh.text = (
			"...The first thing that happens as you step into the foyer of the\n" + 
			"dark mansion is that the door behind you warps, shifts, and\n" +
			"disappears. All light leaves the foyer - then suddenly, a sharp pain,\n" +
			"like a bite, on your neck. You feel lost, confused...and thirsty.\n\n" +
			"WASD to move, F to hide from enemies, Space to pounce on rats");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
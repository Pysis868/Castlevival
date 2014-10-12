using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class Epilogue : MonoBehaviour {

	TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = gameObject.GetComponent<TextMesh>();
		textMesh.text = (
		"You drive the weapon into the sleeping vampire's still heart\n\n" + 
		"With the vampire destroyed, the curse over the castle is lifted,\n" +
		"and sun shines across the halls and rooms of the once dreaded place.\n" +
		"Your fangs shrink, your vision clears, and your thirst for blood\n" +
		"leaves you. You quickly find the exit in the foyer, and head home.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

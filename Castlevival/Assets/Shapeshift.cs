using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Blood))]
public class Shapeshift : MonoBehaviour {
	
	public SkinnedMeshRenderer defaultModel;
	public MeshRenderer newModel;
	public bool shifted = false;
	public AudioSource transformSFX;
	private Blood blood;
	
	// Use this for initialization
	void Start () {
		blood = gameObject.GetComponent<Blood>() as Blood;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)) {
			
			if(shifted == false) {
				//Transform
				shifted = true;
				blood.lossRate *= 2;
				defaultModel.enabled = false;
				newModel.enabled = true;
			} else {
				//Turn back
				shifted = false;
				blood.lossRate /= 2;
				newModel.enabled = false;
				defaultModel.enabled = true;
			}
			transformSFX.Play ();
		}
	}
}

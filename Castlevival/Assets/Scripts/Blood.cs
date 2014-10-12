using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {

	public Light visionLight;
	public float currentBlood;
	public float maxBlood = 100;
	public float lossRate;

	// Use this for initialization
	void Start () {
		currentBlood = maxBlood;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentBlood > 0) {
			currentBlood -= lossRate;
		}
		
		visionLight.spotAngle = 80 * (currentBlood / maxBlood) + (.75f * (maxBlood - currentBlood)/maxBlood);
		visionLight.color = Color.Lerp(Color.red, Color.white, (currentBlood / maxBlood) - (.75f * (maxBlood - currentBlood)/maxBlood) );
	}
	
	public void Add(float amount) {
		currentBlood = Mathf.Clamp (currentBlood + amount, 0f, maxBlood);
	}
	
	public float Proportion() {
		return currentBlood / maxBlood;
	}
}

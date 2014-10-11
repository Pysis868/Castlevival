using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Blood))]
public class Vampire : MonoBehaviour {

	public float jumpDistance = 3;
	
	private Blood blood;

	// Use this for initialization
	void Start () {
		blood = gameObject.GetComponent<Blood>() as Blood;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)) {
			Attack();
		}
	}
	
	//Attack a target. For a vampire, this means jumping at them and sucking their blood!
	public void Attack() {
		RaycastHit hitInfo;
		
		//Find out what we'll hit with a capsule cast (basically a fat raycast)
		if(Physics.CapsuleCast (transform.position - new Vector3(0,.5f, 0), transform.position + new Vector3(0,.5f,0), 0.5f, transform.forward, out hitInfo, jumpDistance * blood.Proportion ())) {
			//Jump at it if its a target and not, say, a wall
			if(hitInfo.collider.gameObject.CompareTag ("Victim")) {
				JumpAt(hitInfo.collider.gameObject);
			}
		}
	}
	
	//Jumps a short distance to a target location using iTween
	public void JumpAt(GameObject target) {
		//iTween jump to target position
		gameObject.GetComponent<CharacterController>().enabled = false;
		iTween.MoveTo (gameObject, iTween.Hash ("x", target.transform.position.x, "y", transform.position.y, "z", target.transform.position.z, "time", .5f, "easetype", iTween.EaseType.easeInOutCubic, "oncomplete", "FeedOn", "oncompleteparams", target));
	}
	
	//Sucks the blood out of a BloodSource
	public void FeedOn(Object target) {
		gameObject.GetComponent<CharacterController>().enabled = true;
		//Cast to a GameObject
		GameObject victim = (GameObject) target;
		//If the target has blood, feed on it
		BloodSource targetBlood = victim.GetComponent<BloodSource>() as BloodSource;
		if(targetBlood) {
			blood.Add(targetBlood.Drain());
		}
		
	}
}

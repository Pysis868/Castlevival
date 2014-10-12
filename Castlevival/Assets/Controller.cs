using UnityEngine;
using System.Collections;

//Holds between-scene information
public class Controller : MonoBehaviour {

	public static bool hasStake;
	public static float blood = 100;
	public int prevLevel = 0;
	public Vector3 spawn1;
	public Vector3 spawn2;
	public Vector3 spawn3;
	public AudioSource bgm1;
	public AudioSource bgm2;
	private GameObject player;
	
	void Awake() {
		Invoke("StartGame", 18f);
	}
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Return) && Application.loadedLevelName.Equals ("Title")) {
			StartGame();
		}
	}
	
	public void PickUpStake() {
		hasStake = true;
		bgm1.Stop ();
		bgm2.Play ();
	}
	
	void OnLevelWasLoaded(int level) {
		player = GameObject.FindGameObjectWithTag ("Player");
		if(!player) {
			prevLevel = level;
			return;
		}
	
		if(level == 1) {
			switch (prevLevel) {
				case 0:
					player.transform.position = spawn1;
					break;
				case 1:			//Died in foyer
					player.transform.position = spawn1;
					break;
				case 2:			//Was upstairs
					player.transform.position = spawn2;
					break;
				case 3:			//Was downstairs
					player.transform.position = spawn3;
					break;
				case 4:
					break;
			}
		}
		prevLevel = level;
	}
	
	void StartGame() {
		Application.LoadLevel ("Floor 1");
	}
	
	public void Win() {
		bgm2.Stop ();
		Invoke("Exit", 18f);
	}
	
	void Exit() {
		Application.Quit ();
	}
	
	
}

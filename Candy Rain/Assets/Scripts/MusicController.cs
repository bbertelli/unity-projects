using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {
	
	public static MusicController instance;

	// Use this for initialization
	void Start () {

		instance = this;
	
	}

	public static void PlaySound(){
		instance.GetComponent<AudioSource>().Play ();
	}

	public static void PauseSound(){
		instance.GetComponent<AudioSource>().Pause ();
	}

	public static void StopSound(){
		instance.GetComponent<AudioSource>().Stop ();
	}
}

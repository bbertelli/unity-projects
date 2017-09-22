using UnityEngine;
using System.Collections;

public enum gameSounds
{
	button,
	fail,
	gameover,
	play,
	point
}

public class SoundFXController : MonoBehaviour {

	public AudioClip soundButtons;
	public AudioClip soundCandyFail;
	public AudioClip soundGameOver;
	public AudioClip soundPlayButton;
	public AudioClip soundPoint;

	public static SoundFXController instance;

	// Use this for initialization
	void Start () {

		instance = this;
	
	}
	
	public static void PlaySound(gameSounds currentSound){
		switch (currentSound) {
		case gameSounds.button:{
			instance.GetComponent<AudioSource>().PlayOneShot(instance.soundButtons);
		}
			break;
		case gameSounds.fail:{
			instance.GetComponent<AudioSource>().PlayOneShot(instance.soundCandyFail);
		}
			break;
		case gameSounds.gameover:{
			instance.GetComponent<AudioSource>().PlayOneShot(instance.soundGameOver);
		}
			break;
		case gameSounds.play:{
			instance.GetComponent<AudioSource>().PlayOneShot(instance.soundPlayButton);
		}
			break;
		case gameSounds.point:{
			instance.GetComponent<AudioSource>().PlayOneShot(instance.soundPoint);
		}
			break;
		}
	}

	/*public static void StopSound(gameSounds currentSound){
		instance.audio.Stop ();
	}*/
}

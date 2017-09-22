using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject pauseButton;
	public GameObject despauseButton;
	public GameObject fadeBackground;
	private GameController gameController;
	private bool isPaused;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType (typeof(GameController)) as GameController;	
	}

	void Update () {
		if (gameController.GetCurrentState () == GameStates.INGAME) {
			if(!isPaused){
				pauseButton.SetActive (true);
			}else{
				despauseButton.SetActive (true);
				fadeBackground.SetActive(true);
			}
		}
		if (gameController.GetCurrentState () == GameStates.RANKING) {
			pauseButton.SetActive (false);
			despauseButton.SetActive (false);
			fadeBackground.SetActive(false);
		}

	}

	public void pausar(){
		pauseButton.SetActive (false);
		despauseButton.SetActive (true);
		fadeBackground.SetActive(true);
		if(gameController.isSound){
			MusicController.PauseSound();
		}
		Time.timeScale = 0;
		isPaused = true;
	}

	public void despausar(){
		despauseButton.SetActive (false);
		fadeBackground.SetActive(false);
		pauseButton.SetActive (true);
		if (gameController.isSound) {
			if (!MusicController.instance.GetComponent<AudioSource>().isPlaying) {
				MusicController.PlaySound ();	
			}
		}
		Time.timeScale = 1;
		isPaused = false;
	}
}

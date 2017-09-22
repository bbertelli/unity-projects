using UnityEngine;
using System.Collections;
using StartApp;

public class GameOverController : MonoBehaviour {

	public TextMesh score;
	public TextMesh bestScore;
	public GameObject content;
	public GameObject newBestScore;
	public GameObject title;
	public GameObject replayBtn;
	public GameObject homeBtn;
	private float currentTimeStartAnimationTitle;
	private float currentTimeStartAnimationContent;
	private float adsTimeCounter;
	private bool adsVerifier;
	public int gameOverCount = 0;
	private bool firstGameOver = true;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType (typeof(GameController)) as GameController;
		HideGameOver ();
		replayBtn.SetActive(false);
		homeBtn.SetActive(false);
		adsVerifier = false;
		#if UNITY_ANDROID && !UNITY_EDITOR
		StartAppWrapper.loadAd();
		#endif
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) { 
						Application.Quit ();
				}

		if (gameController.GetCurrentState () == GameStates.RANKING || gameController.GetCurrentState () == GameStates.GAMEOVER) {
						if (title.GetComponent<Animator> ().GetBool ("CallGameOver")) {
								currentTimeStartAnimationTitle += Time.deltaTime;
			
								if (currentTimeStartAnimationTitle > .2) {
										title.GetComponent<Animator> ().SetBool ("CallGameOver", false);
										currentTimeStartAnimationTitle = 0;
								}
						}

						if (content.GetComponent<Animator> ().GetBool ("CallGameOver")) {
								currentTimeStartAnimationContent += Time.deltaTime;
			
								if (currentTimeStartAnimationContent > .3) {
										content.GetComponent<Animator> ().SetBool ("CallGameOver", false);
										currentTimeStartAnimationContent = 0;

								}
						}
				}
		if (adsVerifier) {
			adsTimeCounter += Time.deltaTime;

			if (adsTimeCounter > .8) {
				if (gameOverCount == 4) {
					
					#if UNITY_ANDROID && !UNITY_EDITOR
					StartAppWrapper.showAd();
					StartAppWrapper.loadAd();
					#endif

					gameOverCount = 0;
				}
					replayBtn.SetActive (true);
					homeBtn.SetActive (true);
				adsVerifier = false;
				adsTimeCounter = 0;
			}
		}

	
	}

	public void SetGameOver(int scoreInGame){

		//#if UNITY_ANDROID && !UNITY_EDITOR
		//	StartAppWrapper.addBanner( 
	    //      StartAppWrapper.BannerType.AUTOMATIC,
	    //      StartAppWrapper.BannerPosition.BOTTOM);
		//#endif

		replayBtn.SetActive(false);
		homeBtn.SetActive(false);

		if(scoreInGame > PlayerPrefs.GetInt("Score")){
			PlayerPrefs.SetInt("Score",scoreInGame);
			newBestScore.SetActive(true);
		}else{
			newBestScore.SetActive(false);
		}

		score.text = scoreInGame.ToString ();
		bestScore.text = PlayerPrefs.GetInt ("Score").ToString ();

		content.SetActive (true);
		title.SetActive (true);

		title.GetComponent<Animator>().SetBool("CallGameOver", true);
		content.GetComponent<Animator>().SetBool("CallGameOver", true);
		adsVerifier = true;
		gameOverCount++;
		firstGameOver = false;
	}

	public void HideGameOver(){
		//if (!firstGameOver) {
		//	#if UNITY_ANDROID && !UNITY_EDITOR
		//	StartAppWrapper.removeBanner();
		//	#endif
		//}
		content.SetActive (false);
		title.SetActive (false);
	}
}

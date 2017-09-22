using UnityEngine;
using System.Collections;
using StartApp;

public enum GameStates{
	START,
	WAITGAME,
	MENU,
	TUTORIAL,
	INGAME,
	GAMEOVER,
	RANKING
}

public class GameController : MonoBehaviour {

	//public Transform chestMaster;
	//private Vector3 startPositionChest;
	public GameObject blueCham;
	public GameObject blueChamGameOver;
	public GameObject yellowCham;
	public GameObject yellowChamGameOver;
	public GameObject redCham;
	public GameObject redChamGameOver;
	public GameObject greenCham;
	public GameObject greenChamGameOver;
	public GameObject pinkCham;
	public GameObject pinkChamGameOver;
	public GameObject purpleCham;
	public GameObject purpleChamGameOver;
	public GameObject orangeCham;
	public GameObject orangeChamGameOver;
	public GameObject brownCham;
	public GameObject brownChamGameOver;
	public GameObject mouthColider;
	public Transform headColider;
	public GameObject buttonGreen;
	public GameObject buttonRed;
	public GameObject buttonYellow;
	public GameObject buttonBlue;
	public GameObject buttonOrange;
	public GameObject buttonPink;
	public GameObject buttonPurple;
	public GameObject buttonBrown;
	public GameObject playerTuto;
	public GameObject candyButtons;
	public GameObject soundButtonOn;
	public GameObject soundButtonOff;
	private GameStates currentState = GameStates.START;
	public TextMesh numberScore;
	public int score;
	private GameOverController gameOverController;
	//private OpenMouthVerifier openMouthVerifier;
	//private StartScreenController startScreenController;
	//public GameObject menu;
	public GameObject tutorial;
	public GameObject title;
	public GameObject playButton;
	public GameObject playButtonBorder;
	public GameObject candyStartScreen;
	//private float currentTimeStartAnimationTextCandy;
	//private float currentTimeStartAnimationTextRain;
	private float currentTimeStartAnimationPlayButton;
	private float currentTimeStartAnimationHeadMouth;
	public float timeToHeadColider;
	public bool headIsFalse = false;
	public bool isSound;
	//public float adTimer;
	//public int verifyChameleonColorGameOver;
	//public int verifyGameOverAnimation;
	//private SpawnController spawnController;
	//private float timeToAnimate;
	//private bool endAnimation = false;
	private const string FACEBOOK_APP_ID = "687709848007661";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	private const string TWITTER_URL = "https://twitter.com/share";

	// Use this for initialization
	void Start () {
		//startPositionChest = chestMaster.position;
		gameOverController = FindObjectOfType (typeof(GameOverController)) as GameOverController;
		isSound = true;
		//openMouthVerifier = FindObjectOfType (typeof(OpenMouthVerifier)) as OpenMouthVerifier;
		//startScreenController = FindObjectOfType (typeof(StartScreenController)) as StartScreenController;
		#if UNITY_ANDROID && !UNITY_EDITOR
		StartAppWrapper.loadAd();
		#endif
	}
	
	// Update is called once per frame
	void Update () {

		switch (currentState) {

		case GameStates.START:{

			//SoundController.PlaySound(gameSounds.music);
			gameOverController.HideGameOver();
			//chestMaster.gameObject.SetActive(false);
			buttonRed.SetActive(false);
			buttonBlue.SetActive(false);
			buttonGreen.SetActive(false);
			buttonYellow.SetActive(false);
			//candyButtons.SetActive(false);
			blueCham.gameObject.SetActive(false);
			blueChamGameOver.gameObject.SetActive(false);
			redCham.gameObject.SetActive(false);
			redChamGameOver.gameObject.SetActive(false);
			greenCham.gameObject.SetActive(false);
			greenChamGameOver.gameObject.SetActive(false);
			yellowCham.gameObject.SetActive(false);
			yellowChamGameOver.gameObject.SetActive(false);
			orangeCham.gameObject.SetActive(false);
			orangeChamGameOver.gameObject.SetActive(false);
			pinkCham.gameObject.SetActive(false);
			pinkChamGameOver.gameObject.SetActive(false);
			purpleCham.gameObject.SetActive(false);
			purpleChamGameOver.gameObject.SetActive(false);
			brownCham.gameObject.SetActive(false);
			brownChamGameOver.gameObject.SetActive(false);
			score = 0;
			numberScore.GetComponent<Renderer>().enabled = false;
			//menu.SetActive(true);
			title.SetActive(true);
			//textCandy.GetComponent<Animator>().SetBool("CallStartScreen", true);
			//textRain.GetComponent<Animator>().SetBool("CallStartScreen", true);
			playButton.SetActive(true);
			playButtonBorder.SetActive(true);
			if(isSound){
				soundButtonOff.SetActive(false);
				soundButtonOn.SetActive(true);
			}else{
				soundButtonOn.SetActive(false);
				soundButtonOff.SetActive(true);
			}
			candyStartScreen.SetActive(true);
			playButton.GetComponent<Animator>().SetBool("CallStartScreen", true);
			if(isSound){
				MusicController.StopSound();
				MusicController.PlaySound();
			}
			currentState = GameStates.MENU;		
			}
			break;
		case GameStates.MENU:{

			//timeToAnimate += Time.deltaTime;

			/*if(textCandy.GetComponent<Animator>().GetBool("CallStartScreen")){
				currentTimeStartAnimationTextCandy += Time.deltaTime;
			
				if(currentTimeStartAnimationTextCandy > .3){
				textCandy.GetComponent<Animator>().SetBool("CallStartScreen", false);
					currentTimeStartAnimationTextCandy = 0;
			}
		}

			if(textRain.GetComponent<Animator>().GetBool("CallStartScreen")){
				currentTimeStartAnimationTextRain += Time.deltaTime;
				
				if(currentTimeStartAnimationTextRain > .3){
					textRain.GetComponent<Animator>().SetBool("CallStartScreen", false);
					currentTimeStartAnimationTextRain = 0;
				}
			}*/



			if(playButton.GetComponent<Animator>().GetBool("CallStartScreen")){
				currentTimeStartAnimationPlayButton += Time.deltaTime;
				
				if(currentTimeStartAnimationPlayButton > .65){
					playButton.GetComponent<Animator>().SetBool("CallStartScreen", false);
					currentTimeStartAnimationPlayButton = 0;
					if(isSound){
						SoundFXController.PlaySound(gameSounds.play);
					}
				}
			}

		}
			break;
		case GameStates.TUTORIAL:{
			
		}
			break;
		case GameStates.WAITGAME:{

		}
			break;
		case GameStates.INGAME:{			
			numberScore.text = score.ToString();

			if(score > 3){
				buttonBrown.SetActive(true);
			}
			if(score > 5){
				buttonPurple.SetActive(true);
			}
			if(score > 10){
				buttonPink.SetActive(true);
			}
			if(score > 15){
				buttonOrange.SetActive(true);
			}

			if(headIsFalse){
				timeToHeadColider += Time.deltaTime;
				if(timeToHeadColider > .58){ //numero de segundos da animaçao / pela numeros de amostras por segundo
					headColider.gameObject.SetActive (true);
					mouthColider.tag = "Untagged";
					headIsFalse = false;
					timeToHeadColider = 0;
				}
			}

			/*if(blueCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "BLUE";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;

				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					blueCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//blueColiderCham.tag = "Untagged";
				}
			}
			if(redCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "RED";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;

				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					redCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//redColiderCham.tag = "Untagged";
				}
			}
			if(yellowCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "YELLOW";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;

				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					yellowCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//yellowColiderCham.tag = "Untagged";
				}
			}
			if(greenCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "GREEN";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;

				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					greenCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//greenColiderCham.tag = "Untagged";
				}
			}
			if(orangeCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "ORANGE";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;
				
				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					orangeCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//greenColiderCham.tag = "Untagged";
				}
			}
			if(pinkCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "PINK";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;
				
				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					pinkCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//greenColiderCham.tag = "Untagged";
				}
			}
			if(purpleCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "PURPLE";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;
				
				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					purpleCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//greenColiderCham.tag = "Untagged";
				}
			}
			if(brownCham.GetComponent<Animator>().GetBool("OpenMouth")){
				mouthColider.tag = "BROWN";
				currentTimeStartAnimationHeadMouth += Time.deltaTime;
				
				if(currentTimeStartAnimationHeadMouth > .6){
					mouthColider.tag = "Untagged";
					headColider.gameObject.SetActive (true);
				}
				
				if(currentTimeStartAnimationHeadMouth > .8){
					brownCham.GetComponent<Animator>().SetBool("OpenMouth", false);
					currentTimeStartAnimationHeadMouth = 0;
					//greenColiderCham.tag = "Untagged";
				}
			}*/
		}
			break;
		case GameStates.GAMEOVER:{

			gameOverController.SetGameOver(score);
			mouthColider.gameObject.SetActive(false);
			currentState = GameStates.RANKING;

		}
			break;
		case GameStates.RANKING:{
			//blueCham.GetComponent<Animator>().SetTrigger("loser");
			//chestMaster.position = startPositionChest;
			numberScore.GetComponent<Renderer>().enabled = false;
			//candyButtons.SetActive(false);

			blueCham.gameObject.SetActive(false);
			yellowCham.gameObject.SetActive(false);
			redCham.gameObject.SetActive(false);
			greenCham.gameObject.SetActive(false);
			brownCham.gameObject.SetActive(false);
			pinkCham.gameObject.SetActive(false);
			purpleCham.gameObject.SetActive(false);
			orangeCham.gameObject.SetActive(false);

			buttonRed.gameObject.SetActive(false);
			buttonYellow.gameObject.SetActive(false);
			buttonGreen.gameObject.SetActive(false);
			buttonBlue.gameObject.SetActive(false);
			buttonPink.gameObject.SetActive(false);
			buttonPurple.gameObject.SetActive(false);
			buttonOrange.gameObject.SetActive(false);
			buttonBrown.gameObject.SetActive(false);
		}
			break;
		}
	
	}

	public void StartGame(){
		//SoundController.PlaySound(gameSounds.music);
		gameOverController.HideGameOver();
		score = 0;
		//verifyChameleonColorGameOver = 1;
		//verifyGameOverAnimation = 0;
		numberScore.GetComponent<Renderer>().enabled = true;
		tutorial.SetActive(false);
		buttonRed.gameObject.SetActive(true);
		buttonYellow.gameObject.SetActive(true);
		buttonGreen.gameObject.SetActive(true);
		buttonBlue.gameObject.SetActive(true);
		headColider.gameObject.SetActive (true);
		mouthColider.gameObject.SetActive (true);
		//candyButtons.SetActive (true);

		blueCham.gameObject.SetActive(true);
		//blueCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		blueChamGameOver.gameObject.SetActive(false);

		redCham.gameObject.SetActive(false);
		redChamGameOver.gameObject.SetActive(false);
		//redCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		yellowCham.gameObject.SetActive(false);
		yellowChamGameOver.gameObject.SetActive(false);
		//yellowCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		greenCham.gameObject.SetActive(false);
		greenChamGameOver.gameObject.SetActive(false);
		//greenCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		orangeCham.gameObject.SetActive(false);
		orangeChamGameOver.gameObject.SetActive(false);
		//orangeCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		pinkCham.gameObject.SetActive(false);
		pinkChamGameOver.gameObject.SetActive(false);
		//pinkCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		purpleCham.gameObject.SetActive(false);
		purpleChamGameOver.gameObject.SetActive(false);
		//purpleCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		brownCham.gameObject.SetActive(false);
		brownChamGameOver.gameObject.SetActive(false);
		//brownCham.GetComponent<Animator>().SetBool("OpenMouth", false);
		currentState = GameStates.INGAME;
	}

	public GameStates GetCurrentState(){
		return currentState;
	}

	public void CallGameOver(){

		if (blueCham.gameObject.activeSelf) {
			blueCham.gameObject.SetActive(false);
			blueChamGameOver.gameObject.SetActive (true);
		}
		if (yellowCham.gameObject.activeSelf) {
			yellowCham.gameObject.SetActive(false);
			yellowChamGameOver.gameObject.SetActive (true);
		}
		if (redCham.gameObject.activeSelf) {
			redCham.gameObject.SetActive(false);
			redChamGameOver.gameObject.SetActive (true);
		}
		if (greenCham.gameObject.activeSelf) {
			greenCham.gameObject.SetActive(false);
			greenChamGameOver.gameObject.SetActive (true);
		}
		if (orangeCham.gameObject.activeSelf) {
			orangeCham.gameObject.SetActive(false);
			orangeChamGameOver.gameObject.SetActive (true);
		}
		if (pinkCham.gameObject.activeSelf) {
			pinkCham.gameObject.SetActive(false);
			pinkChamGameOver.gameObject.SetActive (true);
		}
		if (purpleCham.gameObject.activeSelf) {
			purpleCham.gameObject.SetActive(false);
			purpleChamGameOver.gameObject.SetActive (true);
		}
		if (brownCham.gameObject.activeSelf) {
			brownCham.gameObject.SetActive(false);
			brownChamGameOver.gameObject.SetActive (true);
		}

		currentState = GameStates.GAMEOVER;
	}

	public void CallTutorial(){
		if (isSound) {
			SoundFXController.PlaySound (gameSounds.button);
		}
		currentState = GameStates.TUTORIAL;
		//menu.SetActive(false);
		title.SetActive(false);
		playButton.SetActive(false);
		playButtonBorder.SetActive(false);
		candyStartScreen.SetActive(false);
		soundButtonOn.SetActive (false);
		soundButtonOff.SetActive (false);
		tutorial.SetActive(true);
		//chestMaster.gameObject.SetActive(true);
		playerTuto.SetActive(true);
	}

	public void CallStartScreen(){
		//#if UNITY_ANDROID && !UNITY_EDITOR
		//StartAppWrapper.Destroy();
		//#endif

		if (isSound) {
			SoundFXController.instance.GetComponent<AudioSource>().Stop ();
			SoundFXController.PlaySound (gameSounds.button);
		}
		currentState = GameStates.START;
		RemoveCandyOnGameOver ();
	}

	public void CallBlueHeadAnimation(){
		//blueCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		blueCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "BLUE";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 1;
	}
	public void CallYellowHeadAnimation(){
		//yellowCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		yellowCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "YELLOW";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 2;
	}
	public void CallRedHeadAnimation(){
		//redCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		redCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "RED";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 3;
	}
	public void CallGreenHeadAnimation(){
		//greenCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		greenCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "GREEN";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 4;
	}
	public void CallOrangeHeadAnimation(){
		//orangeCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		orangeCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "ORANGE";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 5;
	}
	public void CallPinkHeadAnimation(){
		//pinkCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		pinkCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "PINK";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 6;
	}
	public void CallPurpleHeadAnimation(){
		//purpleCham.GetComponent<Animator>().SetBool("OpenMouth", true);
		purpleCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "PURPLE";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 7;
	}
	public void CallBrownHeadAnimation(){
		//brownCham.GetComponent<Animator>().SetBool("bite", true);
		brownCham.GetComponent<Animator>().SetTrigger("bite");
		headColider.gameObject.SetActive (false);
		mouthColider.tag = "BROWN";
		headIsFalse = true;
		//verifyChameleonColorGameOver = 8;
	}

	public void ChangeToBlue(){

		yellowCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		blueCham.gameObject.SetActive(true);
		CallBlueHeadAnimation ();

	}

	public void ChangeToYellow(){

		blueCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		yellowCham.gameObject.SetActive(true);
		CallYellowHeadAnimation ();
	}

	public void ChangeToRed(){

		yellowCham.gameObject.SetActive(false);
		blueCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		redCham.gameObject.SetActive(true);
		CallRedHeadAnimation ();
	}

	public void ChangeToGreen(){

		yellowCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		blueCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		greenCham.gameObject.SetActive(true);
		CallGreenHeadAnimation ();
	}

	public void ChangeToOrange(){

		yellowCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		blueCham.gameObject.SetActive(false);

		orangeCham.gameObject.SetActive(true);
		CallOrangeHeadAnimation ();
	}

	public void ChangeToPurple(){

		yellowCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		blueCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		purpleCham.gameObject.SetActive(true);
		CallPurpleHeadAnimation ();
	}

	public void ChangeToPink(){

		yellowCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		brownCham.gameObject.SetActive(false);
		blueCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		pinkCham.gameObject.SetActive(true);
		CallPinkHeadAnimation ();
	}

	public void ChangeToBrown(){

		yellowCham.gameObject.SetActive(false);
		redCham.gameObject.SetActive(false);
		greenCham.gameObject.SetActive(false);
		blueCham.gameObject.SetActive(false);
		pinkCham.gameObject.SetActive(false);
		purpleCham.gameObject.SetActive(false);
		orangeCham.gameObject.SetActive(false);

		brownCham.gameObject.SetActive(true);
		CallBrownHeadAnimation ();
	}

	private void Restart(){
		//#if UNITY_ANDROID && !UNITY_EDITOR
		//StartAppWrapper.Destroy();
		//#endif

		if (isSound) {
			SoundFXController.instance.GetComponent<AudioSource>().Stop ();
			SoundFXController.PlaySound (gameSounds.button);
		}
		//chestMaster.position = startPositionChest;
		StartGame();
		//spawnController.RemoveCandys ();
		RemoveCandyOnGameOver ();
		if (isSound) {
			if (!MusicController.instance.GetComponent<AudioSource>().isPlaying) {
					MusicController.PlaySound ();	
			}
		}
	}

	public void AddScore(){
		score++;
		if (isSound) {
			SoundFXController.PlaySound (gameSounds.point);
		}
	}

	public void RemoveCandyOnGameOver(){

		GameObject candy; 
		if (GameObject.Find ("candy(Clone)")) {
			candy = GameObject.Find ("candy(Clone)");
			if(candy != null){
				Destroy(candy);
			}
		}
	}

	public void SoundOn(){
		SoundFXController.PlaySound (gameSounds.button);
		soundButtonOff.SetActive (false);
		soundButtonOn.SetActive (true);
		SoundFXController.instance.GetComponent<AudioSource>().Play ();
		MusicController.instance.GetComponent<AudioSource>().Play ();
		isSound = true;
	}

	public void SoundOff(){
		soundButtonOn.SetActive (false);
		soundButtonOff.SetActive (true);
		SoundFXController.instance.GetComponent<AudioSource>().Stop ();
		MusicController.instance.GetComponent<AudioSource>().Stop ();
		isSound = false;
	}

	public void ShareToFacebook (){
		int bestScore = PlayerPrefs.GetInt("Score");
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL("http://goo.gl/7C2LaA") +
		                     "&name=" + WWW.EscapeURL("My best score is: "+bestScore.ToString ()+" candies eaten!") +
		                     "&caption=" + WWW.EscapeURL("Download for Android or iOS") + 
		                     "&description=" + WWW.EscapeURL("Can you beat me? Play and try if you can!") + 
		                     "&picture=" + WWW.EscapeURL("") +
		                     "&redirect_uri=" + WWW.EscapeURL("http://www.facebook.com/"));
	}

	public void ShareToTwitter (){
		int bestScore = PlayerPrefs.GetInt("Score");
		Application.OpenURL ( TWITTER_URL + "?url=" + WWW.EscapeURL("http://goo.gl/7C2LaA") +
		                     "&via=" + WWW.EscapeURL("ChamCandiesn'Colours") +
		                     "&hashtags=" + WWW.EscapeURL("games #android #ios") + 
		                     "&text=" + WWW.EscapeURL("My best score is: "+bestScore.ToString ()+" candies eaten! Download it and beat me: "));
	}

}

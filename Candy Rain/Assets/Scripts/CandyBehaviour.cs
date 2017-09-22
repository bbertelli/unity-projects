using UnityEngine;
using System.Collections;

public class CandyBehaviour : MonoBehaviour {

	public GameObject mouthColider;
	//public GameObject openMouthVerifier;
	private GameController gameController;
	//private bool passed;
	public Sprite[] appleSprites;
	public Sprite[] cakeSprites;
	public Sprite[] cherryCupCakeSprites;
	public Sprite[] cupCakesSprites;
	public Sprite[] donutsSprites;
	public Sprite[] donutsFrontSprites;
	public Sprite[] dropsSprites;
	public Sprite[] iceCreamSprites;
	public int randomItem;
	public int randomColor;
	public int randomItemOld = 23;
	public int maxColor = 4;
	//public TextMesh numberScore;
	public int score;
	public int verifyCallGameOver = 0;
	private float rotation;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType(typeof(GameController))as GameController;
		mouthColider = GameObject.Find ("MouthColider");
		appleSprites = Resources.LoadAll<Sprite>("apple");
		cakeSprites = Resources.LoadAll<Sprite>("cake");
		cherryCupCakeSprites = Resources.LoadAll<Sprite>("cherrycupcake");
		cupCakesSprites = Resources.LoadAll<Sprite>("cupcakes");
		donutsSprites = Resources.LoadAll<Sprite>("donuts");
		donutsFrontSprites = Resources.LoadAll<Sprite>("donutsfront");
		dropsSprites = Resources.LoadAll<Sprite>("drops");
		iceCreamSprites = Resources.LoadAll<Sprite>("icecream");
		//score = int.Parse (numberScore.text);
		score = gameController.score;
		if(score > 3){
			maxColor = 5;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
		}
		if(score > 5){
			maxColor = 6;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
		}
		if(score > 10){
			maxColor = 7;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
		}
		if(score > 15){
			maxColor = 8;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
		}

		confCandy ();
		//passed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (verifyCallGameOver != 1) {
						rotation += 200 * Time.deltaTime;

						transform.eulerAngles = new Vector3 (0, 0, rotation);
				}

		/*if (transform.position.y < openMouthVerifier.transform.position.y && !passed) {
			passed = true;
			//gameController.CallBlueHeadAnimation();
		}*/
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log (mouthColider.tag);
		if (gameObject.tag == mouthColider.gameObject.tag) 
		{
			//Debug.Log ("Acertou");
			gameController.AddScore();
			Destroy(gameObject);

		} else {
			if(verifyCallGameOver == 0){
			//Debug.Log ("Errou");
				if(gameController.isSound){
					MusicController.PauseSound();
					SoundFXController.PlaySound(gameSounds.fail);
					//SoundController.instance.audio.Stop();
					SoundFXController.PlaySound(gameSounds.gameover);
				}
				gameController.CallGameOver();
			//Destroy(gameObject);
				verifyCallGameOver = 1;
			}
		}
	}

	void confCandy(){
		randomItem = Random.Range (0,8);
		
		if (randomItemOld == 23) {
			randomItemOld = randomItem;		
		} else {
			while(randomItem == randomItemOld){
				randomItem = Random.Range (0,8);
			}
			randomItemOld = randomItem;
		}
		
		randomColor = Random.Range (0,maxColor);
		
		if (randomItem == 0) {
			gameObject.GetComponent<SpriteRenderer>().sprite = appleSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 1) {
			gameObject.GetComponent<SpriteRenderer>().sprite = cakeSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 2) {
			gameObject.GetComponent<SpriteRenderer>().sprite = cherryCupCakeSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 3) {
			gameObject.GetComponent<SpriteRenderer>().sprite = cupCakesSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 4) {
			gameObject.GetComponent<SpriteRenderer>().sprite = donutsSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 5) {
			gameObject.GetComponent<SpriteRenderer>().sprite = donutsFrontSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 6) {
			gameObject.GetComponent<SpriteRenderer>().sprite = dropsSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
		if (randomItem == 7) {
			gameObject.GetComponent<SpriteRenderer>().sprite = iceCreamSprites[randomColor];
			if (randomColor == 0) {gameObject.tag = "BLUE";}
			if (randomColor == 1) {gameObject.tag = "YELLOW";}
			if (randomColor == 2) {gameObject.tag = "RED";}
			if (randomColor == 3) {gameObject.tag = "GREEN";}
			if (randomColor == 4) {gameObject.tag = "BROWN";}
			if (randomColor == 5) {gameObject.tag = "PURPLE";}
			if (randomColor == 6) {gameObject.tag = "PINK";}
			if (randomColor == 7) {gameObject.tag = "ORANGE";}
		}
	}
}

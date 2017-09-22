using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour {

	public float rateSpawn;
	private float currentRateSpawn;
	private GameController gameController;
	/*public Sprite[] appleSprites;
	public Sprite[] cakeSprites;
	public Sprite[] cherryCupCakeSprites;
	public Sprite[] cupCakesSprites;
	public Sprite[] donutsSprites;
	public Sprite[] donutsFrontSprites;
	public Sprite[] dropsSprites;
	public Sprite[] iceCreamSprites;*/
	public GameObject candy;
	/*public int randomItem;
	public int randomColor;
	public int randomItemOld = 23;*/

	// Use this for initialization
	void Start () {

		gameController = FindObjectOfType (typeof(GameController))as GameController;
		/*appleSprites = Resources.LoadAll<Sprite>("apple");
		cakeSprites = Resources.LoadAll<Sprite>("cake");
		cherryCupCakeSprites = Resources.LoadAll<Sprite>("cherrycupcake");
		cupCakesSprites = Resources.LoadAll<Sprite>("cupcakes");
		donutsSprites = Resources.LoadAll<Sprite>("donuts");
		donutsFrontSprites = Resources.LoadAll<Sprite>("donutsfront");
		dropsSprites = Resources.LoadAll<Sprite>("drops");
		iceCreamSprites = Resources.LoadAll<Sprite>("icecream");*/
	}
	
	// Update is called once per frame
	void Update () {

		if (gameController.GetCurrentState () != GameStates.INGAME)
			return;

		currentRateSpawn += Time.deltaTime;
		if (currentRateSpawn > rateSpawn) {
						currentRateSpawn = 0;
						Spawn ();
		}
	}

	public void Spawn()
	{
		Instantiate(candy);

		/*randomItem = Random.Range (0,8);

		if (randomItemOld == 23) {
			randomItemOld = randomItem;		
		} else {
			while(randomItem == randomItemOld){
				randomItem = Random.Range (0,8);
			}
			randomItemOld = randomItem;
		}

		randomColor = Random.Range (0,8);

		if (randomItem == 0) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = appleSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 1) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = cakeSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 2) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = cherryCupCakeSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 3) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = cupCakesSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 4) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = donutsSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 5) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = donutsFrontSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 6) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = dropsSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}
		if (randomItem == 7) {
			GameObject tempCandy = Instantiate(candy) as GameObject;
			tempCandy.GetComponent<SpriteRenderer>().sprite = iceCreamSprites[randomColor];
			if (randomColor == 0) {tempCandy.tag = "BLUE";}
			if (randomColor == 1) {tempCandy.tag = "YELLOW";}
			if (randomColor == 2) {tempCandy.tag = "RED";}
			if (randomColor == 3) {tempCandy.tag = "GREEN";}
			if (randomColor == 4) {tempCandy.tag = "PINK";}
			if (randomColor == 5) {tempCandy.tag = "ORANGE";}
			if (randomColor == 6) {tempCandy.tag = "PURPLE";}
			if (randomColor == 7) {tempCandy.tag = "BROWN";}
		}*/
	}
}

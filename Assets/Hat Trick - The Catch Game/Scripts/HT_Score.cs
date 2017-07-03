using UnityEngine;
using System.Collections;

public class HT_Score : MonoBehaviour {

    public HT_GameController gameController;

    public GUIText scoreText;
	public int ballValue;

	public int score;

	void Start () {
		score = 0;
		UpdateScore ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		score += ballValue;
		UpdateScore ();
        if(score == 10)
        {
            gameController.won = true;
            gameController.timeLeft = 0;
        }
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Bomb") {
            //score -= ballValue * 2;
            gameController.timeLeft = 0;
            score = 0;
			UpdateScore ();
            gameController.won = false;
		}
	}

	void UpdateScore () {
		scoreText.text = "SCORE:\n" + score;
	}
}

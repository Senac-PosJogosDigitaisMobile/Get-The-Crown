using UnityEngine;
using System.Collections;

public class HT_GameController : MonoBehaviour {

    //public HT_Score scoreControl;

    public Camera cam;
	public GameObject[] balls;
	public float timeLeft;
	public GUIText timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject creditsPop;
    public GameObject backButton;
    public GameObject bgMusic;
    public GameObject winText;
	public HT_HatController hatController;

    public bool won;
	
	private float maxWidth;
	private bool counting;
	
	// Use this for initialization
	void Start () {

        won = false;

		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
	}

	void FixedUpdate () {
		if (counting) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT:\n" + Mathf.RoundToInt (timeLeft);
		}
	}

	public void StartGame () {
		splashScreen.SetActive (false);
		startButton.SetActive (false);
        creditsButton.SetActive(false);
        creditsPop.SetActive(false);
        backButton.SetActive(false);
		hatController.ToggleControl (true);
		StartCoroutine (Spawn ());
	}

    public void Credits()
    {
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        bgMusic.SetActive(false);
        creditsPop.SetActive(true);
        backButton.SetActive(true);
    }

	public IEnumerator Spawn () {
		yield return new WaitForSeconds (1.0f);
		counting = true;
		while (timeLeft > 0) {
			GameObject ball = balls [Random.Range (0, balls.Length)];
			Vector3 spawnPosition = new Vector3 (
				transform.position.x + Random.Range (-maxWidth, maxWidth), 
				transform.position.y, 
				0.0f
			);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
            //yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
            yield return new WaitForSeconds(Random.Range(.1f, 1.0f));
        }
		yield return new WaitForSeconds (0.1f);
        if(won)
        {
            winText.SetActive(true);
        }
        else
        {
            gameOverText.SetActive(true);
        }
		yield return new WaitForSeconds (1.0f);
		restartButton.SetActive (true);
	}
}

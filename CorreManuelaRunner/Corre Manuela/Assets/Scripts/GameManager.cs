using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class GameManager : MonoBehaviour {

	public GameObject pausebutton;
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private PlatormDestroyer[] platformList;
	private ScoreManager theScoreMan;

	public DeathMenu theDeathScreen;

	public AudioSource happyStartSound;

	public bool powerUpReset;
    private RankingsManager rankingManager;

	// Use this for initialization
	void Start () {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://corre-manuela.firebaseio.com");

        platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreMan = FindObjectOfType<ScoreManager>();
        rankingManager = FindObjectOfType<RankingsManager>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame () {
		theScoreMan.scoreIncreasing = false;
        rankingManager.getAllUserScores();
        thePlayer.gameObject.SetActive(false);
		pausebutton.gameObject.SetActive(false);
		theDeathScreen.gameObject.SetActive(true);
		//StartCoroutine ("RestartGameCo"); 	
	}

	public void Reset()
	{
		happyStartSound.Play();
		theDeathScreen.gameObject.SetActive(false);
		pausebutton.gameObject.SetActive(true);
		platformList = FindObjectsOfType<PlatormDestroyer>();
		for (int i = 0; i < platformList.Length; i++) 
		{
			platformList[i].gameObject.SetActive(false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);

		theScoreMan.scoreCount = 0;
		theScoreMan.scoreIncreasing = true;

		powerUpReset = true;
	}

	/* public IEnumerator RestartGameCo() {
		
		yield return new WaitForSeconds(0.5f);
		
	} */

}

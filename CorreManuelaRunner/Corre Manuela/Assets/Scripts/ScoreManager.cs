using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing; 

	public bool shouldDouble;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("Highscore")){
			highScoreCount = PlayerPrefs.GetFloat("Highscore");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreIncreasing){
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat("Highscore", highScoreCount);
		}
		
		scoreText.text = "Score: " + Mathf.Round(scoreCount) ;
		highScoreText.text = "Highscore: " + Mathf.Round(highScoreCount) ;


	}

	public void AddScore (int pointToAdd) 
	{
		if (shouldDouble)
		{
			pointToAdd = pointToAdd *2;
		}
		scoreCount += pointToAdd;
	}

}

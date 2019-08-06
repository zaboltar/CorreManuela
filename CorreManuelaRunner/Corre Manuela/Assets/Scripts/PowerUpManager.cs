using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerUpActive;
    private float powerUpLengthCounter;

    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;

    private float normalPointsPerSecond;
    private float spikeRate;

    private PlatormDestroyer[] spikeList;
    private GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            powerUpLengthCounter -= Time.deltaTime;

            if (theGameManager.powerUpReset)
            {
                powerUpLengthCounter = 0;
                theGameManager.powerUpReset = false;
            }

            if (doublePoints)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond * 2;
                theScoreManager.shouldDouble = true;
            }

            if (safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0f;
            }

            if (powerUpLengthCounter <= 0)
            {
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theScoreManager.shouldDouble = false;

                thePlatformGenerator.randomSpikeThreshold = spikeRate;

                

                powerUpActive = false;
            }
        }
    }

    public void ActivatePowerUp(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerUpLengthCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        spikeRate = thePlatformGenerator.randomSpikeThreshold;

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatormDestroyer>();
		    for (int i = 0; i < spikeList.Length; i++) 
		    {
                if (spikeList[i].gameObject.name.Contains("catSpike") )
                {
                    spikeList[i].gameObject.SetActive(false);
                }
			
		    }
        }
        

        powerUpActive = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	private int platformSelector;
	//public GameObject[] thePlatformSS;
	private float[] platformWidthSS;


	public ObjectPooler[] theObjPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinTreshold;

	public float randomSpikeThreshold;
	public ObjectPooler spikePool;


	// Use this for initialization
	void Start () {


		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;


		platformWidthSS = new float[theObjPools.Length];

		for (int i = 0; i < theObjPools.Length; i++) {
			platformWidthSS[i] = theObjPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range(0, theObjPools.Length);			

			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3(transform.position.x + (platformWidthSS[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);
			
			

			//Instantiate(/*thePlatform*/thePlatformSS[platformSelector], transform.position, transform.rotation);

			
			GameObject newPlatform = theObjPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			if (Random.Range(0f, 100f) < randomCoinTreshold)
			{
				theCoinGenerator.SpawnCoins( new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
			}

			
			if (Random.Range(0f, 100f) < randomSpikeThreshold)
			{
				GameObject newSpike = spikePool.GetPooledObject();

				float spikeXPosition = Random.Range(-platformWidthSS[platformSelector] / 2, platformWidthSS[platformSelector] / 2); 

				Vector3 spikePosition = new Vector3(spikeXPosition, 1.5f, 0f);

				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive(true);
			}
			

			transform.position = new Vector3(transform.position.x + (platformWidthSS[platformSelector]/2), transform.position.y, transform.position.z);
			
		}
	}
}

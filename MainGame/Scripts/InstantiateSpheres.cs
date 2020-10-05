using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class InstantiateSpheres : MonoBehaviour {
    float randomTime;
    float randomXValue;
    public GameObject dropPrefab;
    public float minRandom = 1f;
    public float maxRandom = 3f;
    Coroutine Drops = null;


    // Use this for initialization
    void Start () {
        StartDrops();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //Enumerator that instantiate drops, with random X values and random time in return. Random time in return will change on base of level

    IEnumerator Instantiate() {
        while (true) {
            randomXValue = Random.Range(-3.0f, 3.0f);
            Vector3 position = new Vector3(randomXValue, 10f, 0f);
            Instantiate(dropPrefab, position, dropPrefab.transform.rotation);
            randomTime = Random.Range(minRandom, maxRandom);
            yield return new WaitForSeconds(randomTime);
        }


    }

    //loading levels. Need to stop the active courotine to change the values of random times. Then start the courotine again. Need local methods to start and stop the local courotine.

    public void Level1()
    {
        StopDrops();
        this.minRandom = 0.5f;
        this.maxRandom = 2f;
        Debug.Log("entrou: " + minRandom);
        StartDrops();
    }

    public void Level2()
    {
        StopDrops();
        this.minRandom = 0.2f;
        this.maxRandom = 1f;
        Debug.Log("entrou: " + minRandom);
        StartDrops();
    }

    public void StartDrops()
    {
        Drops = StartCoroutine(Instantiate());
    }

    public void StopDrops()
    {
        StopCoroutine(Drops);
    }

}

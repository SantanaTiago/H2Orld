using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateFaucetRight : MonoBehaviour {

    float randomTime;
    float randomYValue;
    public GameObject faucet;
    //public GameObject water;
    public ScoreControl score;
    public Vector3 position;
    bool torneiraSpawn = false;
    //Coroutine DropsRight = null;
    Ray ray;


    // Use this for initialization
    void Start()
    {

        StartCoroutine(Instantiate());
    }

    // Update is called once per frame
    void Update()
    {
        //check if game is not paused
        if (pauseMenu.gamePaused == false)
        {
            //check if button mouse is clicked
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition); // shoot a ray at the obj from mouse screen point

                //if ray its the object with collider and that have a tag name we want, destroy that object
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Torneira")
                    {
                        Destroy(hit.collider.gameObject);
                        Debug.Log("Destroido torneira");
                        score.StopLocalCoroutineRight();
                        //StopLocalDropsRight();
                        torneiraSpawn = false;
                    }
                }
            }
        }
    }


    IEnumerator Instantiate()
    {
        while (true)
        {
            //check if one faucet are spawned. if not,instatiate one and when is active add minus one to score.
            if (torneiraSpawn == false)
            {
                randomYValue = Random.Range(10f, 6.0f);
                position = new Vector3(4.5f, randomYValue, 2f);
                randomTime = Random.Range(5f, 10f);
                yield return new WaitForSeconds(randomTime);
                Instantiate(faucet, position, faucet.transform.rotation);
                score.StartLocalCoroutineRight();
                //StartLocalDropsRight();
                torneiraSpawn = true;
            }
            else
            {
                yield return new WaitForSeconds(randomTime);
            }
        }

    }

    ////This courotines is instantiate drops os faucet, in case not want to use particle system to simulate.

    //private void StartLocalDropsRight()
    //{
    //    DropsRight = StartCoroutine(waterDropsRight());
    //}

    //private void StopLocalDropsRight()
    //{
    //    StopCoroutine(DropsRight);
    //}

    //IEnumerator waterDropsRight()
    //{
    //    while (true)
    //    {
    //        Vector3 positionDrops = new Vector3(-1f, -1f, 0) + position;
    //        Instantiate(water, positionDrops, Quaternion.identity);
    //        yield return new WaitForSeconds(1f);

    //    }

    //}

}

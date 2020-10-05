using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DestroyOnFloor : MonoBehaviour
{
    public ScoreControl score;

    void Start()
    {
        
    }
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //trigger that happen on contact with floor, adding minus one to score

        if (other.tag == "Sphere")
        {

            Destroy(other.gameObject);
            Debug.Log("Player fail caught ball: -1 score");

            score.MenScoreText();
        }

    }


    

}

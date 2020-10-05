using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class DestroyOnContact : MonoBehaviour {

    public ScoreControl score;
    public AudioSource sound;

    void Start()
    {

    }
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        //trigger that happen if colling with bucket, adding plus one to score

        if (other.tag == "Sphere")
        {

            Destroy(other.gameObject);
            Debug.Log("Player caught ball: +1 score");
            sound.Play();
            score.AddScoreText();
        }
    }


    

}

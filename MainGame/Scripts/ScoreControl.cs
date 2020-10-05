using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{

    public int score;
    int baldes;
    public Text txt;
    public Text txtBalde;
    public Text txtBaldeLoose;
    public pauseMenu pauseM;
    public GameObject loseMenuUi;

    Coroutine FaucetLeftOpen = null;
    Coroutine FaucetRighttOpen = null;

    // Use this for initialization
    void Start()
    {
        MenScoreText();
        AddScoreText();
        OpenFaucetRight();
        OpenFaucetLeft();
        score = 0;
        baldes = 0;
        StartCoroutine(BaldesCounter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenScoreText()
    {
        score -= 1;
        txt.text = "Score: " + score.ToString();
    }


    public void AddScoreText()
    {
        score += 1;
        txt.text = "Score: " + score.ToString();
    }
    #region FaucetRight

    //enumerator that is active when faucet is spawned, adding minus one to score every second
    public IEnumerator OpenFaucetRight()
    {
        while (true)
        {
            score -= 1;
            txt.text = "Score: " + score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }


    public void StartLocalCoroutineRight()
    {
        FaucetRighttOpen = StartCoroutine(OpenFaucetRight());
    }

    public void StopLocalCoroutineRight()
    {
        StopCoroutine(FaucetRighttOpen);
    }
    #endregion

    #region FaucetLeft

    //enumerator that is active when faucet is spawned, adding minus one to score every second

    public IEnumerator OpenFaucetLeft()
    {
        while (true)
        {
            score -= 1;
            txt.text = "Score: " + score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    public void StartLocalCoroutineLeft()
    {
        FaucetLeftOpen = StartCoroutine(OpenFaucetLeft());
    }

    public void StopLocalCoroutineLeft()
    {
        StopCoroutine(FaucetLeftOpen);
    }
    #endregion

    public IEnumerator BaldesCounter()
    {
        //enumerator that count the filled buckets. if score is 3 add one filled. if score is -5, player loses
        while (true)
        {
  
            Debug.Log("Timer: " + baldes);
            if (score == 3)
            {
                baldes++;
                txtBalde.text = "Baldes Cheios: " +baldes.ToString();
                score =0;
                txt.text = "Score: " + score.ToString();

            }
            if (score == -5)
            {
                pauseM.setPaused();
                Time.timeScale = 0f;
                loseMenuUi.SetActive(true);
                txtBaldeLoose.text= "Baldes Cheios: " + baldes.ToString();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

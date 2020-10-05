using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour {

    public Text timer;
    float currTimerValue=0;
    public InstantiateSpheres Level;
    public Text LevelTxt;


    // Use this for initialization
    void Start () {
        LevelTxt.text = "Level 1";
        StartCoroutine(StartTimer());
    }
	
	// Update is called once per frame
	void Update () {
        
	}


    public IEnumerator StartTimer()
    {
        //enumerator that control time on screen
        while (true)
        {
            LevelTxt.text = "";
            currTimerValue++;
            //Debug.Log("Timer: " + currTimerValue);
            timer.text = "Timer: " + currTimerValue.ToString();
            if (currTimerValue == 30)
            {
                Level.Level1();
                LevelTxt.text = "Level 2";
            }
            if (currTimerValue == 60)
            {
                Level.Level2();
                LevelTxt.text = "Level 3";
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}

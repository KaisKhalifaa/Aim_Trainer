using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScript : MonoBehaviour, IsShootable
{
    [SerializeField] TMP_Text countDownUIText;
    [SerializeField] public GameObject pressStartText;
    [SerializeField] GameObject aimBall;
    [SerializeField] AimBallScript aimBallScript;
    public bool trainingStarted=false;
    int i=3;
    void IsShootable.OnShot()
    {
        if (!trainingStarted)
        {
            aimBallScript.scoreInt=0;
            aimBallScript.scoreText.text="0";
            StartCoroutine(StartCountDown());
            pressStartText.SetActive(false);
        }
    }
    private IEnumerator StartCountDown() // this coroutine is for the 3,2,1 countdown for the player to get ready before playing
    {
        countDownUIText.text="4";
        while (i>0)
        {
            countDownUIText.text=(int.Parse(countDownUIText.text)-1).ToString();
            yield return new WaitForSeconds(1f);
            i--;
        }
        i=3;
        countDownUIText.text="";
        trainingStarted = true;
        aimBall.SetActive(true);
        //Debug.Log("training started");
    }
}

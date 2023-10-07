using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    	
	public TMP_Text timer;
	[SerializeField] float minutes,seconds,milliseconds,secondsValue;
	[SerializeField] StartScript startScript;
	[SerializeField] GameObject aimBall;
	void Start(){
		secondsValue = seconds;
	}
	void Update()
	{
		if(startScript.trainingStarted)
		{
    		TimerCountDown();
		}
    }
	void TimerCountDown()//this function is for the training timer to start counting
	{
		if(milliseconds <= 0)
			{
    			if(seconds >= 0)
				{
    				seconds--;
    			}    		
    			milliseconds = 100;
    		}
			milliseconds -= Time.deltaTime * 100;
			timer.text = string.Format("{0}:{1}", seconds, (int)milliseconds);
		if(seconds <= 0) // this condition ends the training, returning everything to its initial value before the training other than the score string that has to show the player his score in that training session.
		{	
			milliseconds = 0;
			seconds = secondsValue; 
			timer.text = "00:00";
			startScript.trainingStarted = false;
			aimBall.SetActive(false);
			startScript.pressStartText.SetActive(true);
		}	
	}
}


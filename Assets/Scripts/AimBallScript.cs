using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AimBallScript : MonoBehaviour, IsShootable
{
    [SerializeField] Transform aimBallSpawnableSurface;
    [SerializeField] AudioSource popSound;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] StartScript startScript;
    public int scoreInt=0;


    void Start(){
        
        RandomizeBallPosition();
    }
    void IsShootable.OnShot()
    {
        popSound.Play();
        scoreInt += 1;
        scoreText.text=scoreInt.ToString();
        if (startScript.trainingStarted == true)
        RandomizeBallPosition();
        //Debug.Log("ball is hit");
    }
    void RandomizeBallPosition()
    {
        Vector3 minPosition = aimBallSpawnableSurface.position - aimBallSpawnableSurface.localScale / 2;
        Vector3 maxPosition = aimBallSpawnableSurface.position + aimBallSpawnableSurface.localScale / 2;

        Vector3 randomAimBallPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(maxPosition.z-1.5f, maxPosition.z-1.5f)
            );
        gameObject.transform.position = randomAimBallPosition;
    
    }
}

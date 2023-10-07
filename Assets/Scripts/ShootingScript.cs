using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot()
    {
        Ray shootingRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if(Physics.Raycast(shootingRay, out hit))
        {
            IsShootable shootableObject = hit.collider.GetComponent<IsShootable>();
            if(shootableObject != null)
            {
                //Debug.Log("Shot thrown");
                shootableObject.OnShot();
            }
            /*if (hit.collider.CompareTag("AimBall"))
            {  
                hit.collider.gameObject.SetActive(false);
                popSound.Play();
            }*/
        }
    }
    
}

using TMPro;
using UnityEngine;

public class SensitivityControl : MonoBehaviour, IsShootable
{
    [SerializeField] MouseLook mouseLookScript;
    [SerializeField] TMP_Text sensitivityText; // onscreen sensitivity text field
    void IsShootable.OnShot()
    {
        if(gameObject.CompareTag("Sens +"))
        {
            mouseLookScript._mouseSensitivity+=0.1f;
            mouseLookScript._mouseSensitivity = Mathf.Round(mouseLookScript._mouseSensitivity * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);
            sensitivityText.text = (mouseLookScript._mouseSensitivity).ToString();
        }
        else if(gameObject.CompareTag("Sens -"))
        {
            if(mouseLookScript._mouseSensitivity>0.1f)
            {
                mouseLookScript._mouseSensitivity-=0.1f;
                mouseLookScript._mouseSensitivity = Mathf.Round(mouseLookScript._mouseSensitivity * Mathf.Pow(10, 2)) / Mathf.Pow(10, 2);
                sensitivityText.text = (mouseLookScript._mouseSensitivity).ToString();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

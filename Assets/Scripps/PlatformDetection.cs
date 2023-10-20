using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformDetection : MonoBehaviour
{
    void Start()
    {
        // Check the platform and perform actions accordingly.
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Debug.Log("You are running on a PC build.");
            SceneManager.LoadScene("Main Menu");
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("You are running on an Android build.");
            SceneManager.LoadScene("Main Menu VR");
        }
        else
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Controls");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Tnx");
        }
    }
}

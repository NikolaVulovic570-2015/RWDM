using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Game");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Tnx");
        }
    }
}

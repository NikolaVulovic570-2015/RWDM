using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(exit());
    }

   
    IEnumerator exit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}

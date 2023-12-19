using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    /// <summary>
    /// Gets called when the try again button pressed on win or lose screen
    /// </summary>
    public void OnPlayButton()
    {
        // loads the start screen
        SceneManager.LoadScene("Start");
    }
}


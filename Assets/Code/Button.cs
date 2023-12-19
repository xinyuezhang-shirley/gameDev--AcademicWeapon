using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    /// <summary>
    /// Gets called when the play button pressed on the starting screen
    /// </summary>
    public void OnPlayButton()
    {
        // loads the game screen
        SceneManager.LoadScene("Game");
    }
}

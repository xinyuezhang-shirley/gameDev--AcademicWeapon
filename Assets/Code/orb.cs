using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event handler for Orb/sand glass objects
/// </summary>
public class Orb : MonoBehaviour
{
    /// <summary>
    /// stores the audio source for the tadaa sound
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// sound file for the tadaa sound (score increase victory)
    /// </summary>
    public AudioClip tadaa;

    /// <summary>
    /// If this gets called, then we're off screen
    /// So destroy ourselves
    /// </summary>
    void OnBecameInvisible()
    {

        Destroy(gameObject);
    }

    /// <summary>
    /// On collision with enemy, play tadaa sound and then destroy
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() == true)
        {
            audioSource.PlayOneShot(tadaa, 0.7F);
            StartCoroutine(WaitAndDestroy(tadaa.length));
        }
    }

    /// <summary>
    /// delays the destruction of the game object for set number of seconds
    /// </summary>
    IEnumerator WaitAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

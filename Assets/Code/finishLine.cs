using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour
{

    /// <summary>
    /// stores the audio source for the ohno sound
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// audio file for the ohno sound (score decrease sadness)
    /// </summary>
    public AudioClip ohno;


    void OnCollisionEnter2D(Collision2D collision)
    {
        //if collides with enemy, play ohno sound
        if (collision.collider.GetComponent<Enemy>() == true)
        {
            audioSource.PlayOneShot(ohno, 0.7F);
        }
    }
}

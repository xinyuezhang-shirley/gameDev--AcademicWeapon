using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    /// <summary>
    /// enemy rigid body component
    /// </summary>
    private Rigidbody2D rigidBody;

    /// <summary>
    /// speed that the enemy moves down
    /// </summary>
    public float downwardSpeed = 1.0f; 

    void Start()
    {
        //stores rigidbody component and initializes velocity
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, -downwardSpeed); // Set the downward velocity
    }

    /// <summary>
    /// handles enemy collisions with orb or finish line and adjusts score
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        //hits an orb, score goes up by 0.1 and destroys
        if (collision.collider.GetComponent<Orb>() == true)
        {

            ScoreKeeper.ScorePoints(0.1f);
            Destroy(gameObject);
        } //hits the finish/deadline, score goes down by 0.1 and destroys
        else if (collision.collider.CompareTag("Finish") == true)
        {

            ScoreKeeper.ScorePoints(-0.1f);
            Destroy(gameObject);
        }
    }


    // on leaving the screen. destroy 
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

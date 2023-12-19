using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class player : MonoBehaviour
{
    /// <summary>
    /// rigid body of the player
    /// </summary>
    public Rigidbody2D body;

    /// <summary>
    /// float determining when the next orb should be fired from enemy
    /// </summary>
    public float nextFire = 0;

    /// <summary>
    /// float determining when the next enemy should be spawned
    /// </summary>
    public float nextEnemy = 0;

    /// <summary>
    /// How fast we go
    /// </summary>
    public float speed = 2;

    /// <summary>
    /// How fast the orb/sand glass goes
    /// </summary>
    public float OrbVelocity = 8;

    /// <summary>
    /// Prefab for the orbs/sand glass we will shoot
    /// </summary>
    public GameObject OrbPrefab;

    /// <summary>
    /// Prefab for the enemies/code that will come at us
    /// </summary>
    public GameObject EnemyPrefab;

    /// <summary>
    /// Period the enemy should wait between shots
    /// </summary>
    public float CoolDownTime = .3f;

    /// <summary>
    /// Period before each enemy spawn
    /// </summary>
    public float enemyCoolDown = 2f;

    /// <summary>
    /// stores the audio source for the keyboard sound
    /// </summary>
    public AudioSource audioSource1;

    /// <summary>
    /// audio file for the keyboard sound (shooting sound) 
    /// </summary>
    public AudioClip keyboard;

    /// <summary>
    /// stores the audio source for the ohno sound
    /// </summary>
    public AudioSource audioSource2;

    /// <summary>
    /// audio file for the ohno sound (score decrease sadness)
    /// </summary>
    public AudioClip ohno;

    /// <summary>
    /// y position of the player, which should never change
    /// </summary>
    public float y;


    void Start()
    {
        //get the rigidbody and the y position of the player
        body = gameObject.GetComponent<Rigidbody2D>();
        y = transform.position.y;
    }


    void FixedUpdate()
    {
        // make sure the y position never changes
        transform.position = new Vector3(transform.position.x, y,0);
      
        Move();

        // fire if indicated and time criteria met
        if (Time.time >= nextFire && Input.GetKey(KeyCode.Space))
        {
            Fire();
            nextFire = Time.time + CoolDownTime;
        }

        // spawn enemy if time criteria met
        if (Time.time >= nextEnemy)
        {
            MakeEnemy();
            nextEnemy = Time.time + enemyCoolDown;
        }

    }

    void MakeEnemy()
    {
        // spawns enemy at random point and rescale enemy
        Vector3 enemySpawn = Spawner.RandomEnemyPoint;
        GameObject enemy = Instantiate(EnemyPrefab, enemySpawn, Quaternion.identity);
        enemy.transform.localScale = new Vector3(0.2f, 0.2f, 0);
    }

    void Fire()
    {

       // spawns orb one unit ahead, sets scale, and assign it velocity
       Vector3 spawnPosition = transform.position + transform.up;

       GameObject orb = Instantiate(OrbPrefab, spawnPosition, Quaternion.identity);
       orb.transform.localScale = new Vector3(0.2f,0.2f,0);
       Rigidbody2D orbBody = orb.GetComponent<Rigidbody2D>();
       orbBody.velocity = OrbVelocity * transform.up;

       // play keyboard sound
       audioSource1.PlayOneShot(keyboard, 0.7F);

    }

    void Move()
    {
        //move when indicated at the direction indicated at constant speed
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(speed, 0);
        }
        else
        {
            body.velocity= new Vector2(0, 0);
        }
    }

    /// <summary>
    /// If this is called, we are off the screen, spawn back and play ohno sound
    /// </summary>
    void OnBecameInvisible()
    {
        ScoreKeeper.ScorePoints(-0.1f);
        transform.position = new Vector2(0,-4);
        audioSource2.PlayOneShot(ohno, 0.7F);
    }
}

using UnityEngine;

/// <summary>
/// Moves this GameObject to a random location on screen should it move off screen
/// It will try to pick a position that has at least FreeRadius units of free space around it.
/// </summary>
public class Spawner : MonoBehaviour
{
    public float FreeRadius = 10;
    /// <summary>
    /// top left point of the screen
    /// </summary>
    public static Vector2 left = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));

    /// <summary>
    /// top tight point of the screen
    /// </summary>
    public static Vector2 right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    /// <summary>
    /// Random enemy starting point at the top of the screen
    /// </summary>
    public static Vector2 RandomEnemyPoint
        => new Vector2(Random.Range(left.x, right.x), Random.Range(left.y, right.y));
}
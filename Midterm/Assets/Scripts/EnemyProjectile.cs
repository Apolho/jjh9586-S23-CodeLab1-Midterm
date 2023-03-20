using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float speed = 40;
    private GameObject player;
    private GameObject enemy;

    
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find(Player.hero + ("(Clone)")); //finds player
        enemy = GameObject.Find("Enemy(Clone)"); //finds enemy
        //makes player direction vector == the distance between the player and the enemy, making it go right to the player
        playerDirection = new Vector2 (player.transform.position.x - enemy.transform.position.x,  - enemy.transform.position.y  + player.transform.position.y);
        rb.AddForce(playerDirection.normalized * speed); //will make the forsce the direction of the player and the speed
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public static float speed;

    public static float health;

    public static int strength;

    public static string hero = "cHero";

    public GameObject gameManager;

    public GameObject weapon;

    public static bool reload = false;
    
   

    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        //will find the game manager
        gameManager = GameObject.Find("GameManager");

        switch (hero) //will check if the hero string equals any of these
        {
            case "sHero": //if == shero, then is will call the square function
                SquareHero();
                break;
            case "cHero": //will call the circle function
                CircleHero();
                break;
            case "tHero": //will call the triangle function
                TriangleHero();
                break;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //WASD controller. Adds force to corresponding vector with the speed of the hero
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speed * Vector2.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(speed * Vector2.down);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(speed * Vector2.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Vector2.right);
        }

        rb.velocity *= 0.09f; //will slow down the velocity so it doesn't go on forever

        if (Input.GetMouseButtonDown(0) && reload == false) //when pressing the left mouse button and if reload is false
        {
            reload = true; //will set reload to true, not allowing this to be done again
            Attack(); //will call the attack function
        }

        if (health <= 0 || GameManager.instance.gameEnd >= 2) //if the player goes under the health threshold or game end reaches 2, they will go to the Game Over screen
        {
            SceneManager.LoadScene("GameOver");
        }
        
     
       
        
    }

    //next few functions set the stats to the corresponding heroes. different health stats, different strength stats, and different speeds
    void SquareHero()
    {
        speed = 10f;
        health = 80;
        strength = 20;
    }

    void CircleHero()
    {
        speed = 20f;
        health = 40;
        strength = 10;
    }

    void TriangleHero()
    {
        
        speed = 15f;
        health = 60;
        strength = 15;
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.name.Contains("Door")) //if it collides with the door
        {
            GameManager.instance.gameEnd++; //when player hits door, it adds one to gameEnd in game manager
            gameManager.GetComponent<ASCIILevelLoader>().LevelChange(); //calls the ASCII level loader and changes the level
            
        }
    }

    public void Attack()
    {
        GameObject newWeapon = Instantiate(weapon); //instantiates a new game object

        
        newWeapon.transform.position = gameObject.transform.position; //instantiates it on the location of the player
        newWeapon.transform.rotation = new Quaternion(Input.mousePosition.x, Input.mousePosition.y, 0, 0).normalized; 
        //rotation will change depending on the mouse position

    }
}

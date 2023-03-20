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

    private int health;

    public static int strength;

    public static string hero = "cHero";

    public GameObject gameManager;

    public GameObject weapon;

    public static bool reload = false;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        gameManager = GameObject.Find("GameManager");

        switch (hero)
        {
            case "sHero":
                SquareHero();
                break;
            case "cHero":
                CircleHero();
                break;
            case "tHero":
                TriangleHero();
                break;
        }
        
        Debug.Log(hero);
        
    }

    // Update is called once per frame
    void Update()
    {
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

        rb.velocity *= 0.09f;

        if (Input.GetMouseButtonDown(0) && reload == false)
        {
            reload = true;
            Attack();
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

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
        if (col.gameObject.name.Contains("Door"))
        {
            Debug.Log("Collided");
            gameManager.GetComponent<ASCIILevelLoader>().LevelChange();
        }
    }

    public void Attack()
    {
        GameObject newWeapon = Instantiate(weapon);

        
        newWeapon.transform.position = gameObject.transform.position;
        newWeapon.transform.rotation = new Quaternion(Input.mousePosition.x, Input.mousePosition.y, 0, 0).normalized;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private float weaponDamage;
    public float weaponSpeed;
    public static float damage;

    private Rigidbody2D rb;

    private Vector3 direction;
   
    
    // Start is called before the first frame update

    void ThrowingKnives()
    {
        weaponDamage = 15; //sets the weapon damage
        weaponSpeed = Player.speed * 25; //sets weapon speed equal to the player speed * a set speed
        damage = Player.strength + weaponDamage; //overall damage is the strength of the player + the weapon's damage
    }

    private void Start()
    {
        ThrowingKnives(); //calls throwing knives to set the stats
        rb = GetComponent<Rigidbody2D>(); //gets the rigidbody
        Vector3 dir = (MousePosition() - GameObject.Find(Player.hero + "(Clone)").transform.position); //creates a vector 3 with the mouse position and subtracts 
                                                                                                        // the position of the player to have it go in the right direction
        rb.AddForce(dir.normalized * weaponSpeed); //adds force with the new vector and the weapon speed

    }
    
    public Vector3 MousePosition()
    {
        Vector3 direction = Input.mousePosition;//creates a Vector3 based on the mouse position, but in pixel coordinates. Gets mouse position in pixels


        direction.z = Camera.main.WorldToScreenPoint(transform.position).z;//gets the depth of the position from the world to the screen.


        return Camera.main.ScreenToWorldPoint(direction);//returns the value to the variable so it is that 3D world coordinate
    }
}

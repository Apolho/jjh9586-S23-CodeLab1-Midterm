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
        weaponDamage = 15;
        weaponSpeed = Player.speed * 25;
        damage = Player.strength + weaponDamage;
    }

    private void Start()
    {
        ThrowingKnives();
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = (MousePosition() - GameObject.Find(Player.hero + "(Clone)").transform.position);
        rb.AddForce(dir.normalized * weaponSpeed);

    }

    private void Update()
    {
        
    }

    public Vector3 MousePosition()
    {
        Vector3 direction = Input.mousePosition;

        direction.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(direction);
    }
}

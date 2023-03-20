using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Throwing Knife") && gameObject.name.Contains("Enemy"))
        {
            Player.reload = false;
            Destroy(col.gameObject);
            gameObject.GetComponent<Enemy1>().enemyHealth -= WeaponDamage.damage;
            Debug.Log("Hit");
        }
        else if (col.gameObject.name.Contains("Throwing Knife") && gameObject.CompareTag("Environment"))
        {
            Player.reload = false;
            Destroy(col.gameObject);
        }

        if (col.gameObject.name.Contains("EnemyProjectile") && gameObject.CompareTag("Environment"))
        {
            Enemy1.shot = false;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name.Contains("EnemyProjectile") && gameObject.CompareTag("Player"))
        {
            
            Enemy1.shot = false;
            Destroy(col.gameObject);
        }
    }
}

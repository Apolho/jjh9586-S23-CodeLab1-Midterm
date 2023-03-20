using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class Triggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Throwing Knife") && gameObject.name.Contains("Enemy")) //if enemy game object and knife collide
        {
            Player.reload = false; //set player reload to false to be able to shoot again
            Destroy(col.gameObject); //destroy knife
            gameObject.GetComponent<Enemy1>().enemyHealth -= WeaponDamage.damage; //and lower enemy health by the damage dealt
         
        }
        else if (col.gameObject.name.Contains("Throwing Knife") && gameObject.CompareTag("Environment")) //if knife hits environment
        {
            Player.reload = false;
            Destroy(col.gameObject);
        }

        if (col.gameObject.name.Contains("EnemyProjectile") && gameObject.CompareTag("Environment")) //if enemy projectile hits environment
        {
            Enemy1.shot = false; //enemy can shoot again
            Destroy(col.gameObject); //destroy projectile
        }
        else if (col.gameObject.name.Contains("EnemyProjectile") && gameObject.CompareTag("Player")) //if hits player
        {
            
            Enemy1.shot = false;
            Player.health -= 10;
            Destroy(col.gameObject);
        }
    }
}

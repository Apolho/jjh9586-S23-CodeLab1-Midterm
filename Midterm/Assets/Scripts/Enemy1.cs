using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Vector2 playerDirection;

    private GameObject player;

    public GameObject projectile;

    public static bool shot = false;

    public float enemyHealth = 80;
    

    // Update is called once per frame
    void Update()
    {
        if (shot == false)
        {
            shot = true;
            EnemyShooting();
        }

        if (enemyHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    void EnemyShooting()
    {
        GameObject bullet = Instantiate(projectile);

        bullet.transform.position = gameObject.transform.position;

    }
}

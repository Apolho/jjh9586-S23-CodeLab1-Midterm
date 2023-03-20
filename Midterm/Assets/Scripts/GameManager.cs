using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] heroes;

    private Vector3 direction;
    
    public int gameEnd = 0;
    

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Player.hero == "sHero")
        {
            gameObject.GetComponent<ASCIILevelLoader>().player = heroes[0];
        }
        else if (Player.hero == "tHero")
        {
            gameObject.GetComponent<ASCIILevelLoader>().player = heroes[1];
        }
        else if(Player.hero == "cHero")
        {
            gameObject.GetComponent<ASCIILevelLoader>().player = heroes[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log(gameEnd);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public string choice;

    public GameObject
        characterButton1,
        characterButton2,
        characterButton3,
        character1,
        character2,
        character3;

    void Awake() //on Awake, it will deactivate all the UI stuff
    {
        characterButton1.SetActive(false);
        characterButton2.SetActive(false);
        characterButton3.SetActive(false);
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //when button clicked to start game, will change text to give players a choice
        displayText.text = choice;
    }
    
    public void SceneChange()
    {
        //will change the scene when button pressed
        SceneManager.LoadScene("GameScene");
    }

    // the next few functions will change the string to match the hero picked in order to instantiate the correct hero
    public void sHero()
    {
       
        Player.hero = "sHero";
    }

    public void cHero()
    {
        Player.hero = "cHero";

    }

    public void tHero()
    {
        Player.hero = "tHero";

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Completed;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private List<Enemy> enemies; //List of all Enemy units, used to issue them move commands.
    private bool gameOver = false;
    
    private Text levelText;									//Text to display current level number.
    private GameObject levelImage;

    private Transform MainHeroPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        enemies = new List<Enemy>();
        
        MainHeroPos = GameObject.FindGameObjectWithTag("Player").transform;

        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    //Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddEnemyToList(Enemy script)
    {
        //Add Enemy to List enemies.
        enemies.Add(script);
    }

    void InitGame()
    {
        //Get a reference to our image LevelImage by finding it by name.
         levelImage = GameObject.Find("LevelImage");

         //Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
         levelText = GameObject.Find("LevelText").GetComponent<Text>();
         
         levelImage.SetActive(false);
         levelText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            gameOver = MoveEnemies();
        }
        else
        {
            levelImage.SetActive(true);
            levelText.text = "GAME OVER";
        }
    }

    //Coroutine to move enemies in sequence.
    bool MoveEnemies()
    {
        var gameOver = false;
        //Loop through List of Enemy objects.
        for (int i = 0; i < enemies.Count; i++)
        {
            gameOver = enemies[i].MoveTo(MainHeroPos);
        }

        return gameOver;
    }
}
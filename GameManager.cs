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
    private List<Tool> tools; 
    private bool gameOver = false;

    public bool gameStarted;

    public List<Enemy> priorEnemies;
    public int maxPrior = 0;

    private Text levelText; //Text to display current level number.
    private GameObject levelImage;

    private Transform MainHeroPos;
    public TimerScript ts;

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
        tools = new List<Tool>();
        priorEnemies = new List<Enemy>();


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
    
    public void AddToolToList(Tool script)
    {
        tools.Add(script);
    }

    public List<Tool> getTools()
    {
        return tools;
    }

    public void AddEnemyToPriorList(Enemy e)
    {
        // Not added yet
        if (e.prior == -1)
        {
            e.prior = maxPrior + 1;
            priorEnemies.Add(e);
            maxPrior++;
        }
    }

    void InitGame()
    {
        //Get a reference to our image LevelImage by finding it by name.
        levelImage = GameObject.Find("LevelImage");

        //Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        levelImage.SetActive(false);
        levelText.text = "";
        gameStarted = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {    
            gameStarted = ts.Run();
        }
        
        if (gameStarted)
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
    }

    //Coroutine to move enemies in sequence.
    bool MoveEnemies()
    {
        var gameOver = false;
        //Loop through List of Enemy objects.
        for (int i = 0; i < enemies.Count; i++)
        {    
            // Not dead
            if (enemies[i].health > 0 && !enemies[i].fight)
            {
                gameOver = enemies[i].MoveTo(MainHeroPos, 1.6f);
            }
        }

        return gameOver;
    }
}
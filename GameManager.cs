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
    public bool gameOver = false;


    public bool gameStarted;

    public List<Enemy> priorEnemies;
    public int maxPrior = 0;

    public int numberOfBoxes;
    private Text levelText; //Text to display current level number.
    private GameObject levelImage;
    private bool musicOn = false;

    private int numOfAliveEnemies;
    
    private GameObject ToolIcon1;
    private GameObject ToolIcon2;
    private GameObject ToolIcon3;

    private Transform MainHeroPos;
    private Transform RobotPos;
    public TimerScript ts;

    public int toHeal = 0;

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
        RobotPos = GameObject.FindGameObjectWithTag("Robot").transform;
        
        DontDestroyOnLoad(gameObject);
        InitGame();
    }

    //Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddEnemyToList(Enemy script)
    {
        //Add Enemy to List enemies.
        enemies.Add(script);
        numOfAliveEnemies++;
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

    public void setNumOfBoxes(int numOfBoxes)
    {
        numberOfBoxes = numOfBoxes;

        if (numberOfBoxes == 1)
        {
            ToolIcon1.SetActive(true);
        }

        if (numberOfBoxes == 2)
        {
            ToolIcon2.SetActive(true);
        }

        if (numberOfBoxes == 3)
        {
            ToolIcon3.SetActive(true);
        }
    }

    void InitGame()
    {
        //Get a reference to our image LevelImage by finding it by name.
        levelImage = GameObject.Find("LevelImage");

        //Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        ToolIcon1 = GameObject.Find("ToolIcon1");
        ToolIcon2 = GameObject.Find("ToolIcon2");
        ToolIcon3 = GameObject.Find("ToolIcon3");

        levelImage.SetActive(false);
        levelText.text = "";

        ToolIcon1.SetActive(false);
        ToolIcon2.SetActive(false);
        ToolIcon3.SetActive(false);


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
        
        Debug.Log(numOfAliveEnemies);
        
        if (gameStarted && numOfAliveEnemies > 0)
        {
            if (!musicOn)
            {
                GameObject.Find("Background").GetComponent<AudioSource>().mute = false;
                musicOn = true;
            }

            if (!gameOver)
            {
                gameOver = MoveEnemies();
            }
            else
            {
                GameObject.Find("Background").GetComponent<AudioSource>().mute = true;
                levelImage.SetActive(true);
                levelText.text = "GAME OVER";
                
            }
        }
        else if (gameStarted && numOfAliveEnemies == 0 && !gameOver)
        {
            GameObject.Find("Background").GetComponent<AudioSource>().mute = true;

            levelImage.SetActive(true);
            levelText.text = "YOU WON";
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

    public void MinusEnemy()
    {
        numOfAliveEnemies--;
    }

    public float distRobotPlayer()
    {
        var thisPosition = RobotPos.position;

        var toPosition = MainHeroPos.position;

        var dist = Vector3.Distance(thisPosition, toPosition);
        return dist;
    }
}
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterController2D
{
    public int maxHP = 100;
    public int curHP = 100;

    public int numberOfBoxes = 0;
    
    private List<Tool> tools;
    protected override void Start()
    {
        base.Start();
        tools = GameManager.instance.getTools();
        speed = 6;
    }
    void Update()
    {
        if (GameManager.instance.distRobotPlayer() < 2f && numberOfBoxes > 0)
        {   
            GameManager.instance.Heal(numberOfBoxes);
            numberOfBoxes--;
            GameManager.instance.toHeal = 20;
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        tools = GameManager.instance.getTools();

        for (int i = 0; i < tools.Count; i++)
        {
            if (Vector3.Distance(tools[i].getPosition(), transform.position) < 1.6f)
            {
                Destroy(tools[i].gameObject);
                tools.RemoveAt(i);
                numberOfBoxes++;
                GameManager.instance.setNumOfBoxes(numberOfBoxes);
            }
        }

        if (GameManager.instance.gameStarted)
        {
            Move(h, v, speed);
        }
    }

    private void FixedUpdate()
    {
    }
}

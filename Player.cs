using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterController2D
{
    public int maxHP = 100;
    public int curHP = 100;

    protected override void Start()
    {
        base.Start();

        speed = 6;
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (GameManager.instance.gameStarted)
        {
            Move(h, v, speed);
        }
    }

    private void FixedUpdate()
    {
    }
}

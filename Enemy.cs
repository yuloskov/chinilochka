using System;
using UnityEngine;
using System.Collections;


public class Enemy : CharacterController2D
{
    public int prior = -1;
    public int health = 100;
    protected override void Start()
    {
        base.Start();
        GameManager.instance.AddEnemyToList(this);
        pos = transform;
        health = 100;
        speed = 2;
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.instance.AddEnemyToPriorList(this);
        }
    }
}
using System;
using UnityEngine;
using System.Collections;


public class Enemy : CharacterController2D
{
    public int prior = -1;
    protected override void Start()
    {
        base.Start();
        GameManager.instance.AddEnemyToList(this);
        pos = transform;
        health = 100;

        health = 100;
        speed = 2;
        attack = 5;
        attackRate = 0.9f;
        passedTime = attackRate;
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.instance.AddEnemyToPriorList(this);
        }
    }

    protected void Update()
    {
        if (fight)
        {
            passedTime += Time.deltaTime;
            if (passedTime >= attackRate)
            {
                passedTime = 0;
                Attack(fightWith);
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log(1);
    }
}
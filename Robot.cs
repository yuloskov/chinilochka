﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : CharacterController2D
{
    // Start is called before the first frame update
    private List<Enemy> refPrior;
    private int curAttackI = -1;

    protected override void Start()
    {
        base.Start();
        pos = transform;

        health = 100;
        speed = 3;
        attack = 30;
        attackRate = 0.1f;
        passedTime = attackRate;

        hb = GetComponentInChildren<Image>();
        
        refPrior = GameManager.instance.priorEnemies;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (health <= 0)
        {
            GameManager.instance.gameOver = true;
        }
        hb.fillAmount = health / 100;
        if (curAttackI == -1)
        {
            curAttackI = refPrior.Count > 0 ? 0 : -1;
        }
        else if (curAttackI >= 0)
        {
            if (GameManager.instance.gameStarted && curAttackI < refPrior.Count && MoveTo(refPrior[curAttackI].transform, 1.6f))
            {
                passedTime += Time.deltaTime;
                if (passedTime >= attackRate)
                {
                    passedTime = 0;
                    if (Attack(refPrior[curAttackI]))
                    {
                        Destroy(refPrior[curAttackI].gameObject);
                        curAttackI++;
                    }
                    else
                    {
                        fight = false;
                    }
                }
            }
        }
    }
}

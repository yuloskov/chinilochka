using System;
using UnityEngine;
using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Completed;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : CharacterController2D
{
    public int prior = -1;
    private Text PriorityText;

    protected override void Start()
    {
        base.Start();
        GameManager.instance.AddEnemyToList(this);
        pos = transform;
        health = 100;
        speed = 2;
        attack = 5;
        attackRate = 0.3f;
        passedTime = attackRate;

        hb = GetComponentInChildren<Image>();
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameManager.instance.AddEnemyToPriorList(this);
            PriorityText = GetComponentInChildren<Text>();
            PriorityText.text = prior.ToString();
            PriorityText.transform.position = new Vector3(0.1f, 0.8f, 0) + transform.position;
        }
    }

    protected void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (PriorityText != null)
            {
                Destroy(PriorityText.gameObject);
            }
        }
        hb.fillAmount = health / 100;
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
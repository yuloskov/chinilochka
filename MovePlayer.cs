using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : CharacterController2D
{
    
    public float speed = 6;
    
    protected override void Start()
    {
        base.Start();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");
        Move(h, v, speed);
    }

    private void FixedUpdate()
    {
    }
}

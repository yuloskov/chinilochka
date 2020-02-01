using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : CharacterController2D
{
    protected override void Start()
    {
        base.Start();

        speed = 6;
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

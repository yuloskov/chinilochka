using UnityEngine;
using System.Collections;

namespace Completed
{
    public class Enemy : CharacterController2D
    {
        protected override void Start()
        {
            base.Start();
            GameManager.instance.AddEnemyToList(this);
            pos = transform;

            speed = 2;
        }

    }
}
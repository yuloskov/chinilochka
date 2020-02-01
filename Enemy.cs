using UnityEngine;
using System.Collections;

namespace Completed
{
    public class Enemy : CharacterController2D
    {
        public int maxHP = 100;
        public int curHP = 100;
        protected override void Start()
        {
            base.Start();
            GameManager.instance.AddEnemyToList(this);
            pos = transform;

            speed = 2;
        }

    }
}
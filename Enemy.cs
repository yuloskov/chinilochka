using UnityEngine;
using System.Collections;

namespace Completed
{
    public class Enemy : CharacterController2D
    {
        private Transform target;
        public float speed;


        protected override void Start()
        {
            GameManager.instance.AddEnemyToList(this);

            target = GameObject.FindGameObjectWithTag("Player").transform;
            speed = 2;

            base.Start();
            Debug.Log(target);
        }


        public bool MoveEnemy()
        {
            var targetPosition = target.position;
            var xPlayer = targetPosition.x;
            var yPlayer = targetPosition.y;

            var enemyPosition = transform.position;
            var xEnemy = enemyPosition.x;
            var yEnemy = enemyPosition.y;

            var moveVector = new Vector2(xPlayer - xEnemy, yPlayer - yEnemy).normalized;

            Move(moveVector.x, moveVector.y, speed);

            var dist = Vector3.Distance(targetPosition, enemyPosition);

            return (dist < 8.5f);
        }
    }
}
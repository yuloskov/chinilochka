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
            
            Debug.Log(dist);
            return (dist < 1.8f);
        }

    }
}
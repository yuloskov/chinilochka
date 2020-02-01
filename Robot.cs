using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : CharacterController2D
{
    // Start is called before the first frame update
    private List<Enemy> refPrior;
    private int curAttackI = -1;
    protected override void Start()
    {
        base.Start();
        pos = transform;

        speed = 3;
        
        refPrior = GameManager.instance.priorEnemies;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (curAttackI == -1)
        {
            curAttackI = refPrior.Count > 0 ? 0 : -1;
        }
        else if (curAttackI >= 0)
        {
            Enemy curAttack = refPrior[curAttackI];
            if (MoveTo(curAttack.transform, 1.6f))
            {
                curAttack.health = 0;
                curAttackI = refPrior.Count > curAttackI+1 ? curAttackI + 1 : -2;
            }
        }
    }
}

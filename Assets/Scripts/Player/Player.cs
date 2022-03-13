using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] public int lives = 3;

    public Unit Combat(EnemyScript opponent)
    {
        Unit result;
        if (opponent.level >= this.level)
        {
            Die();
            opponent.level += this.level;
            result = opponent;
        }
        else
        {
            level += opponent.level;
            result = this;
            Destroy(opponent.gameObject);
        }
        return result;
    }

    public int Combat(Obstacle obstacle)
    {
        int result = this.level;

        this.level += obstacle.level;

        result = this.level;

        return result;

    }


    public override void Die()
    {
        base.Die();
        lives--;
        if (lives < 0)
        {
            lives = 0;
        }
        Debug.Log(lives);
     
    }
}

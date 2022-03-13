using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public string UnitName;
    public int level;


    public delegate void OnDeath(Unit unit);
    public event OnDeath death;

    public virtual Unit Combat(Unit opponent)
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

    public int FightObstacle(Obstacle obstacle)
    {
        int result = this.level;

        this.level += obstacle.level;

        result = this.level;

        return result;

    }

    public virtual void Die()
    {
        Debug.Log("se murio");

        death?.Invoke(this);
       
    }

}

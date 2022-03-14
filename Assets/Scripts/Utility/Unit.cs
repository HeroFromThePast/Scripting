using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public string UnitName;
    public int level;
    public UnitTypes.UnitType type;

    public delegate void OnDeath(Unit unit);
    public event OnDeath death;
    private void Awake()
    {
        if(UnitName == null)
        {
            UnitName = DefaultEnemy.UnitName;
        }

        if(level == 0)
        {
            level = DefaultEnemy.level;
        }

    }

    public virtual void Die()
    {
        Debug.Log("se murio");

        death?.Invoke(this);
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour
{
    public string UnitName;
    public int level;
    public UnitTypes.UnitType type;
    public GameObject towerLevel;
    public Action<Unit> OnDeath;
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
       
    }

    private void OnDestroy()
    {
        OnDeath?.Invoke(this);
    }

}

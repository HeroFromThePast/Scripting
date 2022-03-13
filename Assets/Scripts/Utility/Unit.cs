using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public string UnitName;
    public int level;


    public delegate void OnDeath(Unit unit);
    public event OnDeath death;


    public virtual void Die()
    {
        Debug.Log("se murio");

        death?.Invoke(this);
       
    }

}

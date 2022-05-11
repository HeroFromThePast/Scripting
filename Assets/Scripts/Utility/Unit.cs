using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour
{
    //Base de todas las unidades del juego
    //De este script heredan el player, los enemigos y el nivel de las torres y los objetos de soporte
    public string UnitName;
    public int level;
    public UnitTypes.UnitType type; 
    public GameObject towerLevel;
    public Action<Unit> OnDeath; 
    private void Awake()
    {
        //no entendí muy bien
        if(UnitName == null)
        {
            UnitName = DefaultEnemy.UnitName; //Default Enemy rellena el nivel del enemigo en caso de que se crea un objeto vacío del todo
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

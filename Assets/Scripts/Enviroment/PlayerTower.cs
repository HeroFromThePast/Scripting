using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : Tower
{
    public static PlayerTower instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        PopulateTower(Player.instance);
    }

    public override void OnUnitDeath(Unit unit)
    {
        //Regresar al player a un nivel de su torre 
    }

    public void AddLevel()
    {
        towerLevels.Add(new GameObject().AddComponent<TowerLevelUnit>());
    }
}

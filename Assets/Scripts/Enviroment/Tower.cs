using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Unit> towerLevels = new List<Unit>();

    public delegate void OnTowerDestroy(Tower tower);
    public event OnTowerDestroy towerDestroy;

    public void PopulateTower(Unit unit)
    {
        towerLevels.Add(unit);
        unit.death += OnUnitDeath;
    }

    void OnUnitDeath(Unit unit)
    {
        towerLevels.Remove(unit);

        if(towerLevels.Count <= 0)
        {
            towerDestroy?.Invoke(this);
        }
    }
}

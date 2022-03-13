using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    List<Unit> towerLevels = new List<Unit>();

    public void PopulateTower(Unit unit)
    {
        towerLevels.Add(unit);
        unit.death += OnUnityDeath;
    }

    void OnUnityDeath(Unit unit)
    {
        towerLevels.Remove(unit);

        if(towerLevels.Count <= 0)
        {
            //torre destruida 
        }
    }
}

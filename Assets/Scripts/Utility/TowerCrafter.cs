using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Permitira crear torres a partir de una entidad o un arreglo de entidades


public class TowerCrafter : MonoBehaviour
{
    public Tower CreateTower(Unit unit)
    {
        GameObject towerObject = new GameObject();
        Tower tower = towerObject.AddComponent<Tower>();
        tower.PopulateTower(unit);
        return tower;
    }

    public Tower CreateTower(Unit[] units)
    {
        if (units.Length > 0)
        {
            GameObject towerObject = new GameObject();
            Tower tower = towerObject.AddComponent<Tower>();

            for (int i = 0; i < units.Length; i++)
            {
                if(units[i] != null)
                    tower.PopulateTower(units[i]);
            }

            if(tower.towerLevels.Count > 0)
            {
                return tower;
            }
            else
            {
                Debug.Assert(tower.towerLevels.Count > 0, "The array its empty", this);

                return null;
            }

        }
        else
        {
            Debug.Assert(units.Length > 0,"The array its invalid",this);

            return null;
        }
    }
}

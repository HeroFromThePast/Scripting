using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public List<Unit> towerLevels = new List<Unit>();
    public TowerTypes.TowerType type;
    public delegate void OnTowerDestroy(Tower tower);
    public event OnTowerDestroy towerDestroy;

    public GameObject towerPrefab;
    public GameObject towerPrefabTop;
    public float towerLevelOffset;
    public virtual void PopulateTower(Unit unit)
    {
       
        towerLevels.Add(unit);
        unit.OnDeath += OnUnitDeath;
        GameObject towerLevel = Instantiate(towerPrefab);
        towerLevel.transform.position = (Vector2)transform.position + new Vector2(0, towerLevelOffset * towerLevels.Count - 1);
        unit.towerLevel = towerLevel;
        unit.transform.position = towerLevel.transform.position;
    }

    public virtual void OnUnitDeath(Unit unit)
    {
        towerLevels.Remove(unit);
        Destroy(unit.towerLevel);
        Debug.Log(towerLevels.Count);
        if(towerLevels.Count <= 0)
        {
            towerDestroy?.Invoke(this);
        }
    }
}

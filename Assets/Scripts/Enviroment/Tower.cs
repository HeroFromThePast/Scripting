using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Unit> towerLevels = new List<Unit>();
    public delegate void OnTowerDestroy(Tower tower);

    EnemyScript enemy;
    public event OnTowerDestroy towerDestroy;
    bool fillWithDefault;
    private void Awake()
    {
        GameObject defaultEnemy = new GameObject();
        enemy = defaultEnemy.AddComponent<EnemyScript>();
        enemy.UnitName = "DefaultEnemy";
        enemy.level = 1;
        PopulateTower(enemy);
        fillWithDefault = true;
    }
    public void PopulateTower(Unit unit)
    {
        towerLevels.Add(unit);
        unit.death += OnUnitDeath;

        if (fillWithDefault)
        {
            towerLevels.Remove(enemy);
            fillWithDefault = false;
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int state = 0;
    public List<Tower> enemyTowers = new List<Tower>();

    public void AddTower(Tower tower)
    {
        enemyTowers.Add(tower);
        tower.towerDestroy += TowerDestroyed;
    }

    void TowerDestroyed(Tower tower)
    {
        enemyTowers.Remove(tower);
        Debug.Log("Torre destruida");
        Debug.Log("Torres restantes: " + enemyTowers.Count);
        tower.towerDestroy -= TowerDestroyed;
        Destroy(tower.gameObject);
    }

   
   
}

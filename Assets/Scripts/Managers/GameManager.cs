using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    EnemyTower enemyTower;

    [SerializeField]
    EnemyFactory enemyFactory;

    [SerializeField]
    int TowerLevels;
    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < TowerLevels; i++)
        {
            GameObject enemy = enemyFactory.GetNewEntity("EnemyTest", 3, UnitTypes.UnitType.Enemy);
            enemyTower.PopulateTower(enemy.GetComponent<Unit>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

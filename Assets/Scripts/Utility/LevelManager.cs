using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;


    public List<Tower> enemyTowers = new List<Tower>();
    [Header("Player")]
    [SerializeField]
    Transform playerTowerPoint;
    [SerializeField]
    Transform playerTowerPrefab;

    [Header("Enemy")]
    [SerializeField]
    Transform enemyTowerPoint;
    [SerializeField]
    Transform enemyTowerPrefab;
    [SerializeField]
    float enemyTowerOffset;

    [SerializeField]
    PlayerLiveUpdate liveDisplay;

    int enemyAcumulatedLevel = 0;
    public Action LevelWin;

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
    }

    public void StartLevel()
    {
        CreatePlayerTower();

    }

    void CreatePlayerTower()
    {
        Transform playerTower = Instantiate(playerTowerPrefab, playerTowerPoint.position, Quaternion.identity);
        playerTower.GetComponent<PlayerTower>().CreateSupport(UnityEngine.Random.Range(0, 4), 1, 5);//no entiendo esta línea de código
        RandomizeTowerAmount();
        liveDisplay.GetPlayerReference();
    }

    void RandomizeTowerAmount()
    {
        int towerAmount = UnityEngine.Random.Range(1, 4);//numero de toguers
        for (int i = 0; i < towerAmount; i++)
        {
            Transform enemyTower = Instantiate(enemyTowerPrefab, enemyTowerPoint.position + new Vector3(enemyTowerOffset * enemyTowers.Count,0,0), Quaternion.identity);
            AddTower(enemyTower.GetComponent<EnemyTower>());
            int enemyAmount = CalculateEnemyAmount();
            EnemyFactory factory = enemyTower.GetComponent<EnemyFactory>();
            EnemyTower tower = enemyTower.GetComponent<EnemyTower>();
            for (int j = 0; j < enemyAmount; j++)
            {
                int enemyLevel = CalculateEnemyLevels();
                GameObject enemy = factory.GetNewEntity("Enemy", enemyLevel, UnitTypes.UnitType.Enemy);
                Debug.Log("Asigned level: " + enemy.GetComponent<EnemyScript>().level);
                tower.PopulateTower(enemy.GetComponent<Unit>());
            }

        }

    }

    int CalculateEnemyAmount()
    {
        return UnityEngine.Random.Range(1, 7);
    }

    int CalculateEnemyLevels()
    {
        int enemyLevel = 1;
        int minLevel = 1;
        int maxLevel = 1;

            maxLevel = (PlayerTower.instance.GetTowerLevel() + enemyAcumulatedLevel);//se calcula el nivel máximo a partir del nivel del jugador
            enemyLevel = UnityEngine.Random.Range(minLevel, maxLevel);
            enemyAcumulatedLevel = enemyLevel;
            Debug.Log("Returned level " + enemyLevel);
        
        return enemyLevel;
    }


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


        if(enemyTowers.Count <= 0)
        {
            LevelWin?.Invoke();
        }
    }

   
   
}

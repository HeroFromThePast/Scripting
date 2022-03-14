using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int state = 0;
    public Player player;
    //public EnemyScript enemy;
    public Tower tower;
    public TowerCrafter towerCrafter;

    // Start is called before the first frame update
    void Start()
    {
        //towerCrafter = GetComponent<TowerCrafter>();
        GameObject towerObject = new GameObject();
        towerCrafter = towerObject.AddComponent<TowerCrafter>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyScript enemy = new GameObject().AddComponent<EnemyScript>();
        towerCrafter.CreateTower(enemy, TowerTypes.TowerType.EnemyTower);
    }

   
   
}

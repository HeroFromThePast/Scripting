using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : Tower
{
    public static PlayerTower instance;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject supportObject;
    [SerializeField]
    SupportFactory supportFactory;

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

        if(Player.instance == null)
        {
            Instantiate(player);
        }

        PopulateTower(Player.instance);
        Player.instance.startingPosition = Player.instance.transform.position;

    }

    /// <summary>
    /// Generar los objetos de soporte, el nivel maximo es inclusivo
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="minLevel"></param>
    /// <param name="maxLevel"></param>
    public void CreateSupport(int amount, int minLevel, int maxLevel) //para qué se usan 
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = supportFactory.GetNewEntity("support", Random.Range(0, 4), UnitTypes.UnitType.Support);
            PopulateTower(obj.GetComponent<SupportObj>());
        }
    }

    public override void OnUnitDeath(Unit unit)
    {
        //Regresar al player a un nivel de su torre 
    }

    public int GetTowerLevel()//calcula la torre del player, porque de este depende el nivel de los enemigos
    {
        int towerLevel = 0;
        for (int i = 0; i < towerLevels.Count; i++)
        {
            towerLevel += towerLevels[i].level;
        }

        return towerLevel;
    }

}

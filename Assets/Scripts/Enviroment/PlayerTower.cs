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

    public int SupportObjectsAmount;
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


        for (int i = 0; i < SupportObjectsAmount; i++)
        {
            GameObject obj = Instantiate(supportObject);
            PopulateTower(obj.GetComponent<SupportObj>());
        }
    }

    public override void OnUnitDeath(Unit unit)
    {
        //Regresar al player a un nivel de su torre 
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] string UnitName, faction;
    [SerializeField] public int level;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Combat(Unit opponent)
    {
        if (opponent.level >= this.level)
        {
            Die();
        }
        else
        {
            level += opponent.level;
            Destroy(opponent.gameObject);
        }
    }void Die()
    {
        Debug.Log("se murio");
    }

}

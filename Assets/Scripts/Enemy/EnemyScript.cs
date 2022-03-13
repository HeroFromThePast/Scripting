using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Unit
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Unit playerUnit = collision.gameObject.GetComponent<Unit>();
            playerUnit.Combat(this);
        }
    }

}

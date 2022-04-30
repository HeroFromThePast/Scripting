using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyScript : Unit
{
    [SerializeField]
    TextMeshProUGUI levelDisplay;


    void Start()
    {
        levelDisplay.text = level.ToString();
    }

    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.tag == "Player")
          {
              Unit playerUnit = collision.gameObject.GetComponent<Unit>();
              playerUnit.Combat(this);
          }
      }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : Unit
{
    [SerializeField] 
    public int lives = 3;
    [SerializeField]
    TextMeshProUGUI levelDisplay;
    public static Player instance;

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

        levelDisplay.text = level.ToString();
    }
    public Unit Combat(Unit opponent, UnitTypes.UnitType type)
    {
        Unit result = null;

        switch (type)
        {
            case UnitTypes.UnitType.Player:
                break;
            case UnitTypes.UnitType.Enemy:
                if (opponent.level >= this.level)
                {
                    Die();
                    opponent.level += this.level;
                    result = opponent;
                }
                else
                {
                    level += opponent.level;
                    result = this;
                    PlayerTower.instance.PopulateTower(new GameObject().AddComponent<EnemyScript>());
                    Destroy(opponent.gameObject);
                }
                break;
            case UnitTypes.UnitType.Support:

                this.level += opponent.level;

                result = this;
                break;
            default:
                break;
        }

        return result;
    }



    public override void Die()
    {
        base.Die();
        lives--;
        if (lives < 0)
        {
            lives = 0;
        }
        Debug.Log(lives);
     
    }
}

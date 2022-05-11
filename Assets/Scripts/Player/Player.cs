using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Player : Unit
{
    [SerializeField] 
    public int lives = 3;
    [SerializeField]
    TextMeshProUGUI levelDisplay; //se muestra el nivel
    public static Player instance; 
    public bool enemyKilled; //controla cuando uno lo está agarrando y mata un enemgio, es para que el jugador no arrastre el sprite y mate a todos los enemigos
    public Action OnPlayerfail; 
    public Action OnLiveChange; 
    public Vector2 startingPosition; 
    private void Awake()
    {
        //singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        levelDisplay.text = level.ToString();
        OnLiveChange?.Invoke();
        startingPosition = transform.position;
    }
    //Combate
    public Unit Combat(Unit opponent, UnitTypes.UnitType type)
    {
        Unit result = null;
        //de qué otra forma se pudo haber hecho?
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
                Destroy(opponent.gameObject);
                result = this;
                break;
            default:
                break;
        }
        enemyKilled = true;
        ReturnToTower();
        return result;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Support"))
        {
            Debug.Log("Combat");
            Combat(collision.GetComponent<Unit>(), collision.GetComponent<Unit>().type);
            UpdateLevel();
        }
    }

    void UpdateLevel()
    {
        levelDisplay.text = level.ToString();
    }

    public void ReturnToTower()
    {
        transform.position = startingPosition;
    }


    public override void Die()
    {
        base.Die();
        lives--;
        OnLiveChange?.Invoke();
        if (lives <= 0)
        {
            OnPlayerfail?.Invoke();
        }
        Debug.Log(lives);
     
    }
}

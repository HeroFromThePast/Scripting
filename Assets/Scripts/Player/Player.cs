using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] public int lives = 3;
  
         
                                        



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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] public int lives = 3;
  
         
                                        



    // Start is called before the first frame update


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

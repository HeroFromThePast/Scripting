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
        if(levelDisplay != null)
            levelDisplay.text = level.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SupportObj : Unit
{
    [SerializeField]
    TextMeshProUGUI levelDisplay;

    void Start()
    {
        levelDisplay.text = level.ToString();
    }
}

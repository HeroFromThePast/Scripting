using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLiveUpdate : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void GetPlayerReference()
    {
        Player.instance.OnLiveChange += UpdateLive;
        text.text = "Vidas: " + Player.instance.lives.ToString();
    }

    void UpdateLive()
    {
        text.text = "Vidas: " + Player.instance.lives.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

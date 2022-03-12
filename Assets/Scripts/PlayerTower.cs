using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{

    [SerializeField] GameObject playerTower;
    [SerializeField] public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        player = gameObject;
        Instantiate(playerTower, player.transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    float randX;
    float randY;
    Vector2 whereToSpawn;    


    // Start is called before the first frame update
    void Start()
    {
        randX = Random.Range(-3f, 3f);
        randY = Random.Range(-2f, 2f);
        whereToSpawn = new Vector2(randX, randY);
        Instantiate(player, whereToSpawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

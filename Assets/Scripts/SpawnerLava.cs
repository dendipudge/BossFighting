using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLava : MonoBehaviour
{
    public GameObject lava;
    public GameObject player;
    public bool OneTimeSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<player>().IsLavaUnderYou == true)
        {
            if(OneTimeSpawner == false)
            {
                InvokeRepeating("SpawnLava", 1, 2);
                OneTimeSpawner = true;
            }
        }
    }
    public void SpawnLava()
    {
        float RandomX = Random.Range(-2.15f, 10f);
       GameObject LavaPiece  = Instantiate(lava, new Vector3(RandomX, -28f, 0), Quaternion.identity);
        Destroy(LavaPiece , 1f);       
    }
    




}



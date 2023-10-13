using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerClouds : MonoBehaviour   
{
    
    public GameObject cloudPrefab; 
    public Transform SpawnerTransform;
    public int speed;


    void Start()
    {
        SpawnerTransform = gameObject.GetComponent<Transform>();
        StartCoroutine(Spawner());
    }


    void Update()
    {
        
    }
    private IEnumerator Spawner()
    {
        while (true)
        {

            GameObject cloud = Instantiate(cloudPrefab, SpawnerTransform.position , Quaternion.identity);
            cloud.GetComponent<Cloud>().speed = speed;
            yield return new WaitForSeconds(1);
        }        
    }
}

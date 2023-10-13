using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mech : MonoBehaviour
{
    public GameObject Kotl;
   
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("KL"))
        {
            Kotl.GetComponent<KeeperKoTLL>().GetDamage();
        }

        if (collision.gameObject.tag == "BD")
        {
            Destroy(collision.gameObject);
        }
    }
}

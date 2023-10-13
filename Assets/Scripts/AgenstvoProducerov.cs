using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenstvoProducerov : MonoBehaviour
{
    public bool getLevel5;
    public GameObject player;
    public GameObject Kotl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getLevel5 = player.GetComponent<player>().getLevel5;

        if (getLevel5 == true)
        {
            Kotl.SetActive(true);
        }
        else if (getLevel5 == false)
        {
            Kotl.SetActive(false);
        }
    }
}

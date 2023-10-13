using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BADbOY : MonoBehaviour


{
    public int diraction;// 1 - right , -1 - left  , 0 - stand//
    public bool getLevel4;
    public GameObject player;
    public GameObject patron;
    public bool IsWalking;
    public Vector3 Position;
    public int Hpid;
       
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeDirection());
        InvokeRepeating("Strelba", 0, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        Position = gameObject.GetComponent<Transform>().position;

        getLevel4 = player.GetComponent<player>().getLevel4;

        if (IsWalking == true)
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.right * Time.deltaTime * diraction);
        }
        if (getLevel4 == true)
        {
            IsWalking = true;
        }
        else
        {
            IsWalking = false;
        }

    }
    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            float randNumber = Random.Range(0.3f, 1.7f);
            yield return new WaitForSeconds(randNumber);
            TurnAnotherDiraction();
        }

    }
    void Strelba()
    {
        if (getLevel4 == true)
        {
            Instantiate(patron, Position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "level 4")
        {
            TurnAnotherDiraction();
        }
    }
    public void TurnAnotherDiraction()
    {
        diraction *= -1;
    }
    public void TurnAnothDiraction()
    {
        diraction *= 1;
    }

}

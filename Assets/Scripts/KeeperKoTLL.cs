using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperKoTLL : MonoBehaviour
{
    public GameObject Gyrocopter;
    public int diraction;
    public Color SpiritFon;
    public bool getLevel5;
    public GameObject player;
    public int hpid = 10;
    public Sprite[] Taraska;
    public GameObject HeartOfTarasque;
    public GameObject Vtavernu;
    public bool IsLaunch;
    public GameObject AgenstvoPlatform;
    public GameObject cordon7v1;


    public GameObject mech;

    // Start is called before the first frame update
    void Start()
    {
        AgenstvoPlatform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Translate(Vector2.right * Time.deltaTime * diraction);

        //if (IsLaunch == false)
        //{
        //    StartCoroutine(AnimationaAtack());
        //    IsLaunch = true;
        //}

    }
    private void OnEnable()
    {
        StartCoroutine(AnimationaAtack());
    }
    private void OnDisable()
    {
        StopCoroutine(AnimationaAtack());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "level 5")
        {
            TurnAnotherDiraction();
        }
    }

    public void TurnAnotherDiraction()
    {
        diraction *= -1;
        gameObject.GetComponent<Transform>().localScale = new Vector2(diraction * 10, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


    }

    private IEnumerator AnimationaAtack()
    {
        while (true)
        {
            gameObject.GetComponent<Animator>().Play("ILLUMINATION");
            yield return new WaitForSeconds(5);
        }
    }

    private void SpiritPhone()
    {
        Camera.main.GetComponent<Camera>().backgroundColor = SpiritFon;
    }
    public void GetDamage()
    {
        hpid--;
        HeartOfTarasque.GetComponent<SpriteRenderer>().sprite = Taraska[hpid];
        if (hpid <= 0)
        {
            Instantiate(Vtavernu, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);           
            Camera.main.GetComponent<Camera>().backgroundColor = Color.white;
            Gyrocopter.GetComponent<AudioSource>().Play();
            AgenstvoPlatform.SetActive(true);
           
        }
        
    }

}

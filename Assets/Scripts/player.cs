using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour 
{
    public GameObject mech;
    public float speed;
    public float jumpForce;
    public bool touchGround;
    public int kolmon;
    public Text textMonetka;
    public Animator animator;
    public bool getLevel4;
    public bool IsAtacked;
    public int PudgevoiHuk;
    public int hpid;
    public GameObject[] hearts;
    public Sprite RedHeart;
    public Sprite BlackHeart;
    public GameObject GameOver;
    public bool IsTouchingZoneKotl;
    public bool getLevel5;
    public GameObject Kotl;
    public GameObject nadpys;
    public GameObject Furion;
    public GameObject Prycol, buttonbuy,TextDoYouEnter,buttonYes,buttonNo,Skills,RegenarateHp, nadpysss,buttonCloseShopPanel;
    public bool lestnica;
    public bool MogyLiYaIspolsovatFirstSkill;
    public bool IsLavaUnderYou;


    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {

        hpid = 3;
        animator = gameObject.GetComponent<Animator>();
        PudgevoiHuk = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        ArmiyaBymachnyxCamoletikov();

        if(gameObject.GetComponent<Rigidbody2D>().velocity.y==0)
        {
            touchGround = true;
        }
        if (Input.GetKey(KeyCode.W) && lestnica == true)
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && lestnica == true)
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.N))
        {
            gameObject.GetComponent<Transform>().localScale = new Vector2(20, 20);
        }
        else if (Input.GetKeyUp(KeyCode.N))
        {
            gameObject.GetComponent<Transform>().localScale = new Vector2(7, 7);
        }

        if (IsAtacked == true)
        {
            animator.Play("ataka titanov");
        }

        if (Input.GetMouseButtonDown(0))
        {
            IsAtacked = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.right * speed * Time.deltaTime);
            gameObject.GetComponent<Transform>().localScale = new Vector3(-7, 7, 1);
            animator.Play("€ бегаю");
        }



        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Transform>().Translate(Vector2.left * speed * Time.deltaTime);
            gameObject.GetComponent<Transform>().localScale = new Vector3(7, 7, 1);
            animator.Play("€ бегаю");
        }
        else if (IsAtacked == false)
        {
            animator.Play("€ стою");
        }

        

        if (kolmon == 10)
        {
            Furion.SetActive(true);
            nadpys.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (touchGround == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        if (touchGround == true)
        {

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LytsheByYaNeSholVles")
        {
            if ((gameObject.GetComponent<Transform>().position.y <= collision.gameObject.GetComponent<Transform>().position.y))
            {
                Debug.Log("»зијегисЌа6левле");
                gameObject.GetComponent<player>().hpid--;
                ShowHp();
            }
        }
        touchGround = true;//только когда косаетьс€ земли//
        if (collision.gameObject.tag == "monetka")
        {
            kolmon += 1;
            textMonetka.text = kolmon.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "level 2")
        {
            if (gameObject.GetComponent<Transform>().position.x
                <= collision.gameObject.GetComponent<Transform>().position.x)
            {
                gameObject.GetComponent<Transform>().position = new Vector2(12.88f, -0.55f);
                Camera.main.GetComponent<Transform>().position = new Vector2(20.25f, 0);
            }
            else
            {
                gameObject.GetComponent<Transform>().position = new Vector2(21.36f, -1.64f);
                Camera.main.GetComponent<Transform>().position = new Vector2(20.25f, 0);
            }
        }
        if (collision.gameObject.tag == "level 1")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(0.02f, -0.1f);
            Camera.main.GetComponent<Transform>().position = new Vector2(0, 0);
        }
        if (collision.gameObject.tag == "level 3")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(36.92f, -1.49f);
            Camera.main.GetComponent<Transform>().position = new Vector2(38.24f, 0.52f);

        }
        if (collision.gameObject.tag == "level 4")
        {
            if ((gameObject.GetComponent<Transform>().position.x <= collision.gameObject.GetComponent<Transform>().position.x))
            {
                gameObject.GetComponent<Transform>().position = new Vector2(55.29f, -2.13f);
                Camera.main.GetComponent<Transform>().position = new Vector2(62.8f, -0.42f);
                getLevel4 = true;
            }

            else
            {
                gameObject.GetComponent<Transform>().position = new Vector2(48.12f, -2.44f);
                Camera.main.GetComponent<Transform>().position = new Vector2(38.24f, 0.52f);
                getLevel4 = false;
            }
        }
        if (collision.gameObject.tag == "level 5")
        {
            if ((gameObject.GetComponent<Transform>().position.x <= collision.gameObject.GetComponent<Transform>().position.x))
            {

                gameObject.GetComponent<Transform>().position = new Vector2(78.77f, -2.37202f);
                Camera.main.GetComponent<Transform>().position = new Vector2(85.55f, -0.24f);
                getLevel5 = true;

            }

            else
            {
                gameObject.GetComponent<Transform>().position = new Vector2(70.088f, -3.2438f);
                Camera.main.GetComponent<Transform>().position = new Vector2(62.8f, -0.42f);
                getLevel5 = false;
            }
        }
        if (collision.gameObject.tag == "Vertical1")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(90.64f, 8.83f);
            Camera.main.GetComponent<Transform>().position = new Vector2(86.34f, 11.41f);
        }
        if (collision.gameObject.tag == "Vertical2")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(89.96f, 22.94f);
            Camera.main.GetComponent<Transform>().position = new Vector2(86.34f, 22.92f);
        }
        if (collision.gameObject.tag == "Vertical3")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(86.34f, 32.65f);
            Camera.main.GetComponent<Transform>().position = new Vector2(86.55f, 32.57f);
            if (kolmon < 10)
            {
                nadpys.SetActive(true);
                Prycol.GetComponent<AudioSource>().Play();
            }
        }
        if (collision.gameObject.tag == "SecondSpell")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(-44.91f, -38.03f);
            Camera.main.GetComponent<Transform>().position = new Vector2(-42.31f, -35.04f);
        }
        if (collision.gameObject.tag == "ThirdSpell")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(-19.87f, -34.57f);
            Camera.main.GetComponent<Transform>().position = new Vector2(-21.68f, -35.08f);
        }
        if(collision.gameObject.tag == "Magazin")
        {
            buttonNo.SetActive(true);
            buttonYes.SetActive(true);
            TextDoYouEnter.SetActive(true);
            
        }
        if (collision.gameObject.tag == "Lavovy")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(2.48f, -30.26f);
            Camera.main.GetComponent<Transform>().position = new Vector2(2.49f, -29.84f);
            Camera.main.GetComponent<Camera>().backgroundColor = Color.red;
            IsLavaUnderYou = true;
        }

        

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        touchGround = false;
           
        
    }
    

    public void EndAttack()
    {
        IsAtacked = false;
    }
    public void ArmiyaBymachnyxCamoletikov()
    {   if(MogyLiYaIspolsovatFirstSkill == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hpid += 1;
                ShowHp();
                MogyLiYaIspolsovatFirstSkill = false;
                StartCoroutine(RegenateHP());
            }
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Patron")
        {
            Destroy(collision.gameObject);
            hpid--;
            Debug.Log("” теб€ осталось два hp");
            ShowHp();
        }
        //if (collision.gameObject.tag == "KOTL")
        //{
        //    hpid--;
        //    ShowHp();
        //    Debug.Log("XAXXAXAXAXAXAXAXAXAXA");
        //}

        if(collision.gameObject.tag == "KOTL")
        {
            IsTouchingZoneKotl = true;
        }
        if (collision.gameObject.tag == "Lestnica")
        {
            lestnica = true;
        }
        if (collision.gameObject.tag == "Magazin")
        {

        }
        if (collision.gameObject.tag == "Lavova")
        {
            hpid -= 1;
            ShowHp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KOTL")
        {
            IsTouchingZoneKotl = false;
        }
        if (collision.gameObject.tag == "Lestnica")
        {
            lestnica = false;
        }
    }

    bool OneTimeDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KOTL")
        {
            if (OneTimeDamage == false)
            {
                StartCoroutine(ILLUMINATION());
                Debug.Log("XAXXAXAXAXAXAXAXAXAXA");
                OneTimeDamage = true;
            }

        }
    }

    public void CloseShopPanel()
    {       
        buttonNo.SetActive(false);
        buttonYes.SetActive(false);
        TextDoYouEnter.SetActive(false);
        touchGround = true;
    }
    public void OpenShopPanel()
    {
        buttonNo.SetActive(false);
        buttonYes.SetActive(false);
        TextDoYouEnter.SetActive(false);
        buttonbuy.SetActive(true);
    }
    public void CloseMagazin()
    {       
        TextDoYouEnter.SetActive(false);
        buttonNo.SetActive(false);
        buttonYes.SetActive(false);
        nadpysss.SetActive(false);
        buttonbuy.SetActive(false);
        buttonCloseShopPanel.SetActive(false);


    }
    public void BuyFirstSkill()
    {
        if(kolmon >= 11)
        {
            Debug.Log("изи счет 0 30 на шелли");
            Skills.SetActive(true);
            RegenarateHp.SetActive(true);
            buttonbuy.SetActive(false);
            MogyLiYaIspolsovatFirstSkill = true;
            kolmon -= 11; 
            textMonetka.text = kolmon.ToString();

        }
        else if(kolmon < 11)
        {           
            nadpysss.SetActive(true);
            buttonCloseShopPanel.SetActive(true);
        }
       
    }
    public  IEnumerator RegenateHP()
    {
        yield return new WaitForSeconds(55);
        MogyLiYaIspolsovatFirstSkill = true;
    }


    private IEnumerator ILLUMINATION()
    {
        while(true)
        {
            if(IsTouchingZoneKotl == true)
            {
                hpid--;
                ShowHp();

            }
            yield return new WaitForSeconds(6f);
        }
    }

    public void ShowHp()
    {
        if(hpid == 3)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = RedHeart;
            hearts[1].GetComponent<SpriteRenderer>().sprite = RedHeart;
            hearts[2].GetComponent<SpriteRenderer>().sprite = RedHeart;
        }
        if (hpid == 2)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            hearts[1].GetComponent<SpriteRenderer>().sprite = RedHeart;
            hearts[2].GetComponent<SpriteRenderer>().sprite = RedHeart;
        }
        if (hpid == 1)
        {
            hearts[0].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            hearts[1].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            hearts[2].GetComponent<SpriteRenderer>().sprite = RedHeart;
        }
        if (hpid == 0)
        {
            hearts[2].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            hearts[1].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            hearts[0].GetComponent<SpriteRenderer>().sprite = BlackHeart;
            GameOver.SetActive(true);
        }
        

    }
    public void StartAttack()
    {
        mech.GetComponent<PolygonCollider2D>().enabled=(true);        
    }







}

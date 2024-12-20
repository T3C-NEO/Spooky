using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class snake : MonoBehaviour
{
    int skin;
    string direc = "left";
    float timer;
    public float length;
    public bool gameOver;

    public List<GameObject> snaaake = new List<GameObject>();
    public GameObject square;
    public List<GameObject> foods = new List<GameObject> ();
    public GameObject[] allFoods;

    public GameObject end;

    Sprite pumpkin1;
    Sprite pumpkin2;
    Sprite pumpkin3;

    public Sprite pumpO1;
    public Sprite pumpO2;
    public Sprite pumpO3;
    public Sprite pumpB1;
    public Sprite pumpB2;
    public Sprite pumpB3;
    public Sprite pumpP1;
    public Sprite pumpP2;
    public Sprite pumpP3;

    public SpriteRenderer me;

    public AudioSource nom;

    public Sprite arrow;
    public heads soNo;

    //menu shit
    public int health = 2;
    public Image[] hearts;

    public Image upgreadHeads;
    public Sprite[] headOptions;
    public TextMeshProUGUI upgradeCost;

    public Sprite grayHeart;

    public Button[] headClicks;

    public GameObject upgrade;
    public GameObject hruh;

    public float chanceSoph;
    public float chanceDam;
    public float chancePre;
    public float chance240;
    public float chanceKry;
    public float chanceBli;
    public float chanceDan;
    public float chanceAud;
    public float chanceSkr;

    public float speed;

    bool started;

    void Start()
    {
        Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
        Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
        chanceSoph += 3;
        soNo.UpdateChance();
        pumpkin2 = pumpO1;
        pumpkin1 = pumpO2;
        pumpkin3 = pumpO3;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("escape") || Input.GetKeyDown("a") ||
            Input.GetKeyDown("w") || Input.GetKeyDown("d") ||
            Input.GetKeyDown("s") || Input.GetKeyDown("space") || Input.GetKeyDown("enter"))
            && !gameOver && started == true && upgrade.active)
            upgrade.SetActive(false);
        else if(!upgrade.active && (Input.GetKeyDown("escape") || Input.GetKeyDown("space")))
            upgrade.SetActive(true);
        if (Input.GetKeyDown("space") && gameOver)
        {
            Restar();
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            direc = "right";
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            direc = "left";
            transform.localScale = new Vector3(-1, 1, 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            direc = "up";
            if (transform.localScale.x == 1)
                transform.eulerAngles = new Vector3(0, 0, 90);
            else
                transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            direc = "down";
            if (transform.localScale.x == -1)
                transform.eulerAngles = new Vector3(0, 0, 90);
            else
                transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
    private void FixedUpdate()
    {
        if (!gameOver && !upgrade.active && !hruh.active)
        {
            started = true;
            timer += ((snaaake.Count / speed) + 1f);
            if (timer >= 25 && me.sprite == pumpkin1)
            {
                me.sprite = pumpkin2;
            }
            if (timer >= 50)
            {
                me.sprite = pumpkin1;
                GoGoGo();
                timer = 0;
            }
        }
    }

    void GoGoGo()
    {
        for (int i = snaaake.Count-1; i > 0; i--)
        {
            snaaake[i].transform.position = snaaake[i - 1].transform.position;
        }
        if (direc == "right")
        {
            transform.position += new Vector3(1, 0, 0);
            if (transform.position.x == 10)
                transform.position += new Vector3(-19, 0, 0);
        }
        else if (direc == "left")
        {
            transform.position += new Vector3(-1, 0, 0);
            if (transform.position.x == -10)
                transform.position += new Vector3(19, 0, 0);

        }
        else if (direc == "up")
        {
            transform.position += new Vector3(0, 1, 0);
            if (transform.position.y == 6)
                transform.position += new Vector3(0, -11, 0);

        }
        else if (direc == "down")
        {
            transform.position += new Vector3(0, -1, 0);
            if (transform.position.y == -6)
                transform.position += new Vector3(0, 11, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            Summoning();
            soNo.head += int.Parse(collision.name.Substring(0, 4));
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Finish")
        {
            gameOver = true;
            end.SetActive(true);
        }
        else
        {
            hearts[health].sprite = grayHeart;
            health--;
            if (health < 0)
            {
                gameOver = true;
                end.SetActive(true);
            }

        }

    }
    public void Restar()
    {
        SceneManager.LoadScene(0);
    }
    public void Summoning()
    {
        snaaake.Add(Instantiate(square, snaaake[snaaake.Count-1].transform.position, Quaternion.identity));
        snaaake[snaaake.Count-1].GetComponent<SpriteRenderer>().sprite = pumpkin3;
        Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-8, 8), Random.Range(-4, 5)), Quaternion.identity);
        nom.pitch = Random.Range(0.8f, 1.1f);
        nom.Play();
    }
    public void UpgradeHeads()
    {
        if (upgreadHeads.sprite == headOptions[0] && soNo.head >= 1)
        {
            foods.Add(allFoods[0]);
            soNo.head -= 1;
            chanceSoph += 1;
        }
        else if(upgreadHeads.sprite == headOptions[1] && soNo.head >= 2)
        {
            foods.Add(allFoods[1]);
            soNo.head -= 2;
            chanceDam += 1;
        }
        else if(upgreadHeads.sprite == headOptions[2] && soNo.head >= 5)
        {
            foods.Add(allFoods[2]);
            soNo.head -= 5;
            chancePre += 1;
        }
        else if(upgreadHeads.sprite == headOptions[3] && soNo.head >= 10)
        {
            foods.Add(allFoods[3]);
            soNo.head -= 10;
            chance240 += 1;
        }
        else if(upgreadHeads.sprite == headOptions[4] && soNo.head >= 25)
        {
            foods.Add(allFoods[4]);
            soNo.head -= 25;
            chanceKry += 1;
        }
        else if(upgreadHeads.sprite == headOptions[5] && soNo.head >= 50)
        {
            foods.Add(allFoods[5]);
            soNo.head -= 50;
            chanceBli += 1;
        }
        else if(upgreadHeads.sprite == headOptions[6] && soNo.head >= 100)
        {
            foods.Add(allFoods[6]);
            soNo.head -= 100;
            chanceDan += 1;
        }
        else if(upgreadHeads.sprite == headOptions[7] && soNo.head >= 500)
        {
            foods.Add(allFoods[7]);
            soNo.head -= 500;
            chanceAud += 1;
        }
        else if(upgreadHeads.sprite == headOptions[8] && soNo.head >= 1000)
        {
            foods.Add(allFoods[8]);
            soNo.head -= 1000;
            chanceSkr += 1;
        }
        upgreadHeads.sprite = arrow;
        upgradeCost.text = "Click Below!";
        soNo.UpdateChance();
    }
    public void UpgradeHeadsPart2()
    {
        upgreadHeads.sprite = headOptions[int.Parse(EventSystem.current.currentSelectedGameObject.tag)];

        if (upgreadHeads.sprite == headOptions[0])
            upgradeCost.text = 1 + " head";
        else if (upgreadHeads.sprite == headOptions[1])
            upgradeCost.text = 2 + " heads";
        else if (upgreadHeads.sprite == headOptions[2])
            upgradeCost.text = 5 + " heads";
        else if (upgreadHeads.sprite == headOptions[3])
            upgradeCost.text = 10 + " heads";
        else if (upgreadHeads.sprite == headOptions[4])
            upgradeCost.text = 25 + " heads";
        else if (upgreadHeads.sprite == headOptions[5])
            upgradeCost.text = 50 + " heads";
        else if (upgreadHeads.sprite == headOptions[6])
            upgradeCost.text = 100 + " heads";
        else if (upgreadHeads.sprite == headOptions[7])
            upgradeCost.text = 500 + " heads";
        else if (upgreadHeads.sprite == headOptions[8])
            upgradeCost.text = 1000 + " heads";


            /*
             * 
            if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 0 && soNo.head >= 1)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 1;
                chanceSoph += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 1 && soNo.head >= 2)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 2;
                chanceDam += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 2 && soNo.head >= 5)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 5;
                chancePre += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 3 && soNo.head >= 10)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 10;
                chance240 += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 4 && soNo.head >= 25)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 25;
                chanceKry += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 5 && soNo.head >= 50)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 50;
                chanceBli += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 6 && soNo.head >= 100)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 100;
                chanceDan += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 7 && soNo.head >= 500)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 500;
                chanceAud += 1;
            }
            else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 8 && soNo.head >= 1000)
            {
                foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);
                soNo.head -= 1000;
                chanceSkr += 1;
            }
    */


    }
    public void UpdateSkin()
    {
        int i = skin;
        while (i == skin)
        {
            i = Random.Range(0, 3);
        }
        skin = i;
        if (skin == 0)
        {
            pumpkin2 = pumpO1;
            pumpkin1 = pumpO2;
            pumpkin3 = pumpO3;
        }
        else if (skin == 1)
        {
            pumpkin2 = pumpB1;
            pumpkin1 = pumpB2;
            pumpkin3 = pumpB3;
        }
        else if (skin == 2)
        {
            pumpkin2 = pumpP1;
            pumpkin1 = pumpP2;
            pumpkin3 = pumpP3;
        }
        for (i = 1; i < snaaake.Count; i++)
            snaaake[i].GetComponent<SpriteRenderer>().sprite = pumpkin3;

        me.sprite = pumpkin2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class snake : MonoBehaviour
{
    string direc = "left";
    float timer;
    public float length;
    bool gameOver;

    public List<GameObject> snaaake = new List<GameObject>();
    public GameObject square;
    public List<GameObject> foods = new List<GameObject> ();
    public GameObject[] allFoods;

    public GameObject end;

    public Sprite pumpkin1;
    public Sprite pumpkin2;
    public SpriteRenderer me;

    public AudioSource nom;

    public heads soNo;

    //menu shit
    public int health = 2;
    public Image[] hearts;

    public Sprite grayHeart;

    public Button[] headClicks;

    public GameObject upgrade;

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

    void Start()
    {
        Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
        Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
        chanceSoph += 10;
        soNo.UpdateChance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !gameOver)
        {
            upgrade.SetActive(!upgrade.active);
        }
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
        if (!gameOver && !upgrade.active)
        {
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
        }
        else if (direc == "left")
        {
            transform.position += new Vector3(-1, 0, 0);

        }
        else if (direc == "up")
        {
            transform.position += new Vector3(0, 1, 0);

        }
        else if (direc == "down")
        {
            transform.position += new Vector3(0, -1, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            Summoning();
            soNo.head += int.Parse(collision.name.Substring(0, 1));
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
    void Summoning()
    {
        snaaake.Add(Instantiate(square, snaaake[snaaake.Count-1].transform.position, Quaternion.identity));
        Instantiate(foods[Random.Range(0, foods.Count)], new Vector2(Random.Range(-8, 8), Random.Range(-4, 5)), Quaternion.identity);
        nom.pitch = Random.Range(0.8f, 1.1f);
        nom.Play();
    }
    public void UpgradeHeads()
    {
        for (int i = 0; i < headClicks.Length; i++)
        {
            headClicks[i].interactable = true;
        }
    }
    public void UpgradeHeadsPart2()
    {
        Debug.Log(int.Parse(EventSystem.current.currentSelectedGameObject.tag));
        foods.Add(allFoods[int.Parse(EventSystem.current.currentSelectedGameObject.tag)]);

        if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 0 && soNo.head >= 1)
        {
            soNo.head -= 1;
            chanceSoph += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 1 && soNo.head >= 2)
        {
            soNo.head -= 2;
            chanceDam += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 2 && soNo.head >= 5)
        {
            soNo.head -= 5;
            chancePre += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 3 && soNo.head >= 10)
        {
            soNo.head -= 10;
            chance240 += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 4 && soNo.head >= 25)
        {
            soNo.head -= 25;
            chanceKry += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 5 && soNo.head >= 50)
        {
            soNo.head -= 50;
            chanceBli += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 6 && soNo.head >= 100)
        {
            soNo.head -= 100;
            chanceDan += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 7 && soNo.head >= 500)
        {
            soNo.head -= 500;
            chanceAud += 1;
        }
        else if (int.Parse(EventSystem.current.currentSelectedGameObject.tag) == 8 && soNo.head >= 1000)
        {
            soNo.head -= 1000;
            chanceSkr += 1;
        }



        for (int i = 0; i < headClicks.Length; i++)
        {
            headClicks[i].interactable = false;
        }
        soNo.UpdateChance();
    }

}

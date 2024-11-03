using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snake : MonoBehaviour
{
    string direc = "left";
    float timer;
    public float length;
    bool gameOver;

    public List<GameObject> snaaake = new List<GameObject>();
    public GameObject square;
    public GameObject[] foods;

    public GameObject end;

    public Sprite pumpkin1;
    public Sprite pumpkin2;
    public SpriteRenderer me;

    public AudioSource nom;

    void Start()
    {
        Instantiate(foods[Random.Range(0, foods.Length)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
        Instantiate(foods[Random.Range(0, foods.Length)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
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
        if (!gameOver)
        {
            timer += ((snaaake.Count / 10f) + 1f);
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
            Destroy(collision.gameObject);
        }
        else
        {
            gameOver = true;
            end.SetActive(true);
        }

    }
    public void Restar()
    {
        SceneManager.LoadScene(0);
    }
    void Summoning()
    {
        snaaake.Add(Instantiate(square, snaaake[snaaake.Count-1].transform.position, Quaternion.identity));
        Instantiate(foods[Random.Range(0, foods.Length)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
        nom.pitch = Random.Range(0.8f, 1.1f);
        nom.Play();
    }
}

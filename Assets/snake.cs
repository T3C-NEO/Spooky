using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    string direc = "left";
    float timer;
    public float length;
    bool gameOver;

    public List<GameObject> snaaake = new List<GameObject>();
    public GameObject square;
    public GameObject[] foods;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            direc = "right";
            transform.sca
        }
        if (Input.GetKeyDown("left"))
        {
            direc = "left";
        }
        if (Input.GetKeyDown("up"))
        {
            direc = "up";
        }
        if (Input.GetKeyDown("down"))
        {
            direc = "down";
        }
        if (!gameOver)
        {
            timer += Time.deltaTime * ((snaaake.Count / 10f) + 1f);
            if (timer >= 1)
            {
                Debug.Log((snaaake.Count / 10f) + 1f);
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
        }

    }
    void Summoning()
    {
        snaaake.Add(Instantiate(square, snaaake[snaaake.Count-1].transform.position, Quaternion.identity));
        Instantiate(foods[Random.Range(0, foods.Length)], new Vector2(Random.Range(-8, 9), Random.Range(-4, 5)), Quaternion.identity);
    }
}

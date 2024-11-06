using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class badSnake : MonoBehaviour
{
    int direc = 0;
    float timer;
    public float length;
    bool gameOver;

    public List<GameObject> snaaake = new List<GameObject>();
    public GameObject square;
    public GameObject[] foods;


    public Sprite pumpkin1;
    public Sprite pumpkin2;
    public SpriteRenderer me;

    public AudioSource nom;

    bool goTime;

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
        if (direc == 2 || direc == 6)
        {
            transform.position += new Vector3(1, 0, 0);
        }
        else if (direc == 0 || direc == 5)
        {
            transform.position += new Vector3(-1, 0, 0);

        }
        else if (direc == 1)
        {
            transform.position += new Vector3(0, 1, 0);

        }
        else if (direc == 3)
        {
            transform.position += new Vector3(0, -1, 0);

        }
        while (goTime == false)
        {
            goTime = true;
            direc = Random.Range(0, 6);
            if (transform.position.y == 3 && direc == 1)
            {
                goTime = false;
            }
            else if (transform.position.y == -3 && direc == 3)
            {
                goTime = false;
            }
            else if (transform.position.x == 7 && (direc == 2 || direc == 6))
            {
                goTime = false;
            }
            else if (transform.position.x == -7 && (direc == 0 || direc == 5))
            {
                goTime = false;
            }

        }
        goTime= false;
        if (direc == 2 || direc == 6)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (direc == 0 || direc == 5)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (direc == 1)
        {
            if (transform.localScale.x == 1)
                transform.eulerAngles = new Vector3(0, 0, 90);
            else
                transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (direc == 3)
        {
            if (transform.localScale.x == -1)
                transform.eulerAngles = new Vector3(0, 0, 90);
            else
                transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
}

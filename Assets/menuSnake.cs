using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuSnake : MonoBehaviour
{
    public GameObject main;
    int timer;
    public Image me;
    public Sprite pumpkin1;
    public Sprite pumpkin2;
    public List<GameObject> snaaake = new List<GameObject>();

    string direc = "right";

    private void FixedUpdate()
    {
        if (main.active)
        {
            timer += 1;
            if (timer >= 15 && me.sprite == pumpkin1)
            {
                me.sprite = pumpkin2;
            }
            if (timer >= 30)
            {
                me.sprite = pumpkin1;
                GoGoGo();
                timer = 0;
            }
        }
        if (transform.localPosition == new Vector3(400,100,0))
        {
            direc = "down";
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (transform.localPosition == new Vector3(400,-200,0))
        {
            direc = "left";
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (transform.localPosition == new Vector3(-400,-200,0))
        {
            direc = "up";
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (transform.localPosition == new Vector3(-400,100,0))
        {
            direc = "right";
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void GoGoGo()
    {
        for (int i = snaaake.Count - 1; i > 0; i--)
        {
            snaaake[i].transform.localPosition = snaaake[i - 1].transform.localPosition;
        }
        if (direc == "right")
        {
            transform.localPosition += new Vector3(100, 0, 0);
        }
        else if (direc == "left")
        {
            transform.localPosition += new Vector3(-100, 0, 0);

        }
        else if (direc == "up")
        {
            transform.localPosition += new Vector3(0, 100, 0);

        }
        else if (direc == "down")
        {
            transform.localPosition += new Vector3(0, -100, 0);

        }
    }
}

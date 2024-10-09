using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    string direc = "right";
    double timer;
    public float length;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            direc = "right";
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
            timer += Time.deltaTime * ((length / 10) + 1);
            if (timer >= 1)
            {
                GoGoGo();
                timer = 0;
            }
        }
    }

    void GoGoGo()
    {
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
    private void OnCollisionEnter(Collision collision)
    {
        gameOver= true;
    }
}

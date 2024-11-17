using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENUS : MonoBehaviour
{
    public GameObject instructions;
    public GameObject upgrades;
    public GameObject menu;
    public GameObject bar;
    bool where = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("down") || Input.GetKeyDown("s")) && menu.active)
        {
            where = true;
            bar.transform.localPosition = new Vector3(0, -174, 0);
            bar.transform.localScale = new Vector3(1.5f, 1, 1);

        }
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && menu.active)
        {
            where = false;
            bar.transform.localPosition = new Vector3(0, 0, 0);
            bar.transform.localScale = new Vector3(1, 1, 1);
        }
        if (!upgrades.active && (menu.active || instructions.active))
            upgrades.SetActive(true);
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("escape")) && instructions.active)
        {
            if (!menu.active)
            {
                menu.gameObject.SetActive(true);
            }
            else
            {
                if (where == false)
                {
                    instructions.SetActive(false);
                    upgrades.SetActive(false);
                    menu.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("where");
                    menu.gameObject.SetActive(false);
                }
            }
        }
    }
}

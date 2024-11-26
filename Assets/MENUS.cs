using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENUS : MonoBehaviour
{
    public GameObject instructions;
    public GameObject upgrades;
    public GameObject menu;
    bool where = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (menu.active)
            {
                upgrades.SetActive(true);
                menu.SetActive(false);
            } else
            {
                instructions.SetActive(false);
                upgrades.SetActive(false);
            }
        }
    }
}

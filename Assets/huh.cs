using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class huh : MonoBehaviour
{
    public GameObject huhh;
    public TextMeshProUGUI text;

    private void Update()
    {
        if (huhh.active && Input.anyKeyDown)
            huhh.SetActive(false);
    }
    public void HeadsHuh()
    {
        huhh.SetActive(true);
    }
}

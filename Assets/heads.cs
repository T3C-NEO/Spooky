using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class heads : MonoBehaviour
{
    public snake snak;

    public int head;

    public int swapCost;
    public int autoCost;
    public int upgradeCost;
    public int lowerCost;
    public int healCost;

    public TextMeshProUGUI swapCostText;
    public TextMeshProUGUI autoCostText;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI lowerCostText;
    public TextMeshProUGUI healCostText;

    public TextMeshProUGUI display;

    public Sprite redHeart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = " heads: "+ head;
    }

    public void Heals()
    {
        if (snak.health < 2 && head >= healCost)
        {
            snak.health++;
            snak.hearts[snak.health].sprite = redHeart;
            head -= healCost;
            healCost *= 2;
            healCostText.text = healCost + " heads";
        }
        else
        {
            Debug.Log("nah, not gonna do that");
        }
    }
}

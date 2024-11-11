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
    public int lowerCost;
    public int healCost;

    public TextMeshProUGUI swapCostText;
    public TextMeshProUGUI autoCostText;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI lowerCostText;
    public TextMeshProUGUI healCostText;

    public TextMeshProUGUI display;

    public Sprite redHeart;


    public TextMeshProUGUI chanceSoph;
    public TextMeshProUGUI chanceDam;
    public TextMeshProUGUI chancePre;
    public TextMeshProUGUI chance240;
    public TextMeshProUGUI chanceKry;
    public TextMeshProUGUI chanceBli;
    public TextMeshProUGUI chanceDan;
    public TextMeshProUGUI chanceAud;
    public TextMeshProUGUI chanceSkr;

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

    public void UpdateChance()
    {
        chanceSoph.text = Mathf.Round(((snak.chanceSoph / snak.foods.Count) * 100f)).ToString()+"%";
        chanceDam.text = Mathf.Round(((snak.chanceDam / snak.foods.Count) * 100f)).ToString()+"%";
        chancePre.text = Mathf.Round(((snak.chancePre / snak.foods.Count) * 100f)).ToString()+"%";
        chance240.text = Mathf.Round(((snak.chance240 / snak.foods.Count) * 100f)).ToString()+"%";
        chanceKry.text = Mathf.Round(((snak.chanceKry / snak.foods.Count) * 100f)).ToString()+"%";
        chanceBli.text = Mathf.Round(((snak.chanceBli / snak.foods.Count) * 100f)).ToString()+"%";
        chanceDan.text = Mathf.Round(((snak.chanceDan / snak.foods.Count) * 100f)).ToString()+"%";
        chanceAud.text = Mathf.Round(((snak.chanceAud / snak.foods.Count) * 100f)).ToString()+"%";
        chanceSkr.text = Mathf.Round(((snak.chanceSkr / snak.foods.Count) * 100f)).ToString()+"%";
    }

    public void UpgradeSpeed()
    {
        if (head >= lowerCost)
        {
            head -= lowerCost;
            snak.speed += 10;
            lowerCost *= 2;
            lowerCostText.text = lowerCost +" heads";
        }
    }
}

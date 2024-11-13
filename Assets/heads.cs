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

    float collect = 80000000;

    public GameObject window;

    public TextMeshProUGUI swapCostText;
    public TextMeshProUGUI autoCostText;
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
        swapCostText.text = swapCost + " heads";
        autoCostText.text = autoCost + " heads";
        lowerCostText.text = lowerCost + " heads";
        healCostText.text = healCost + " heads";

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
            lowerCostText.text = lowerCost + " heads";
        }
    }
    public void AutoCollect()
    {
        if (head >= autoCost)
        {
            if (collect > 4)
            {
                collect = 8;
                StartCoroutine(MySexyCoroutine());
            }
            head -= autoCost;
            autoCost *= 10;
            collect /= 2;
            autoCostText.text = autoCost + " heads";
        }
    }
    public IEnumerator MySexyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(collect);
            if (!window.active)
            {
                if (snak.chanceSkr > 0)
                    head += 1000;
                else if (snak.chanceAud > 0)
                    head += 500;
                else if (snak.chanceDan > 0)
                    head += 100;
                else if (snak.chanceBli > 0)
                    head += 50;
                else if (snak.chanceKry > 0)
                    head += 25;
                else if (snak.chance240 > 0)
                    head += 10;
                else if (snak.chancePre > 0)
                    head += 5;
                else if (snak.chanceDam > 0)
                    head += 2;
                else
                    head += 1;
            }
            yield return null; 
        }
    }
}

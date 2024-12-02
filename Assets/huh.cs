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
        if (huhh.active && Input.anyKeyDown && text.text != "Remember you can buy upgrades at the shop! (space/esc or click icon)")
            huhh.SetActive(false);
        if (huhh.active && (Input.GetMouseButtonDown(0)|| Input.GetKeyDown("escape")) && text.text == "Remember you can buy upgrades at the shop! (space/esc or click icon)")
            huhh.SetActive(false);
    }
    public void HeadsHuh()
    {
        huhh.SetActive(true);
        text.text = "The heads you've collected. Use them at the shop for upgrades!";
    }
    public void HeartsHuh()
    {
        huhh.SetActive(true);
        text.text = "Your health. You'll lose one if you run into a skull or your pumpkins!";
    }
    public void ShopHuh()
    {
        huhh.SetActive(true);
        text.text = "The shop! Click on it to spend heads on upgrades and cosmetics!";
    }
    public void SwapHuh()
    {
        huhh.SetActive(true);
        text.text = "Changes the colors of you and your pumpkins!";
    }
    public void AutoHuh()
    {
        huhh.SetActive(true);
        text.text = "Lets you passively gain heads. So efficient!";
    }
    public void UpgradeHuh()
    {
        huhh.SetActive(true);
        text.text = "Click a head below, then buy it here to up its odds of appearing!";
    }
    public void LowerHuh()
    {
        huhh.SetActive(true);
        text.text = "Lowers your speed.\nUse this if you get overwhelmed!";
    }
    public void HealHuh()
    {
        huhh.SetActive(true);
        text.text = "Heals one missing heart!";
    }
    public void ChanceHuh()
    {
        huhh.SetActive(true);
        text.text = "The chance each head has of showing up and how much its worth!";
    }
}

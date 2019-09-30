using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float costMultiplier = 1.16f;

    [Header("Scipts")]
    public Towers towers;
    public PlayerStats playerStats;

    [Header("UI")]
    public Text tower1CostText;
    public Text tower2CostText, tower3CostText, tower4CostText, tower5CostText, tower6CostText, tower7CostText, tower8CostText, tower9CostText, tower10CostText;
    public Image tower1DamageBar, tower1FireRateBar, tower2DamageBar, tower2FireRateBar, tower3DamageBar, tower3FireRateBar, tower4DamageBar, tower4FireRateBar,
        tower5DamageBar, tower5FireRateBar, tower6DamageBar, tower6FireRateBar, tower7DamageBar, tower7FireRateBar, tower8DamageBar, tower8FireRateBar,
        tower9DamageBar, tower9FireRateBar, tower10DamageBar, tower10FireRateBar;

    [Header("Slots")]
    public GameObject slot1;
    public GameObject slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9, slot10;

    List<Slot> slotList;

    Slot emptySlot;

    private void Start()
    {
        slotList = new List<Slot>();

        slotList.Add(slot1.GetComponent<Slot>());
        slotList.Add(slot2.GetComponent<Slot>());
        slotList.Add(slot3.GetComponent<Slot>());
        slotList.Add(slot4.GetComponent<Slot>());
        slotList.Add(slot5.GetComponent<Slot>());
        slotList.Add(slot6.GetComponent<Slot>());
        slotList.Add(slot7.GetComponent<Slot>());
        slotList.Add(slot8.GetComponent<Slot>());
        slotList.Add(slot9.GetComponent<Slot>());
        slotList.Add(slot10.GetComponent<Slot>());

        UpdateTowerCostText();
        DefineTowerDmgAndFireRateBars();
    }

    // set value to bars
    void DefineTowerDmgAndFireRateBars()
    {
        tower1DamageBar.fillAmount = towers.tower1.damage / towers.maxDamage;
        tower1FireRateBar.fillAmount = towers.tower1.fireRate / towers.maxFirerate;

        tower2DamageBar.fillAmount = towers.tower2.damage / towers.maxDamage;
        tower2FireRateBar.fillAmount = towers.tower2.fireRate / towers.maxFirerate;

        tower3DamageBar.fillAmount = towers.tower3.damage / towers.maxDamage;
        tower3FireRateBar.fillAmount = towers.tower3.fireRate / towers.maxFirerate;

        tower4DamageBar.fillAmount = towers.tower4.damage / towers.maxDamage;
        tower4FireRateBar.fillAmount = towers.tower4.fireRate / towers.maxFirerate;

        tower5DamageBar.fillAmount = towers.tower5.damage / towers.maxDamage;
        tower5FireRateBar.fillAmount = towers.tower5.fireRate / towers.maxFirerate;

        tower6DamageBar.fillAmount = towers.tower6.damage / towers.maxDamage;
        tower6FireRateBar.fillAmount = towers.tower6.fireRate / towers.maxFirerate;

        tower7DamageBar.fillAmount = towers.tower7.damage / towers.maxDamage;
        tower7FireRateBar.fillAmount = towers.tower7.fireRate / towers.maxFirerate;

        tower8DamageBar.fillAmount = towers.tower8.damage / towers.maxDamage;
        tower8FireRateBar.fillAmount = towers.tower8.fireRate / towers.maxFirerate;

        tower9DamageBar.fillAmount = towers.tower9.damage / towers.maxDamage;
        tower9FireRateBar.fillAmount = towers.tower9.fireRate / towers.maxFirerate;

        tower10DamageBar.fillAmount = towers.tower10.damage / towers.maxDamage;
        tower10FireRateBar.fillAmount = towers.tower10.fireRate / towers.maxFirerate;
    }

    void UpdateTowerCostText()
    {
        tower1CostText.text = playerStats.GetTransformedMoneyText(towers.tower1.cost);
        tower2CostText.text = playerStats.GetTransformedMoneyText(towers.tower2.cost);
        tower3CostText.text = playerStats.GetTransformedMoneyText(towers.tower3.cost);
        tower4CostText.text = playerStats.GetTransformedMoneyText(towers.tower4.cost);
        tower5CostText.text = playerStats.GetTransformedMoneyText(towers.tower5.cost);
        tower6CostText.text = playerStats.GetTransformedMoneyText(towers.tower6.cost);
        tower7CostText.text = playerStats.GetTransformedMoneyText(towers.tower7.cost);
        tower8CostText.text = playerStats.GetTransformedMoneyText(towers.tower8.cost);
        tower9CostText.text = playerStats.GetTransformedMoneyText(towers.tower9.cost);
        tower10CostText.text = playerStats.GetTransformedMoneyText(towers.tower10.cost);
    }

    public void BuyTower1()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower1.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower1);
        playerStats.ManageMoney(-towers.tower1.cost);

        // update tower cost
        towers.tower1.cost = (int)(towers.tower1.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower2()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower2.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower2);
        playerStats.ManageMoney(-towers.tower2.cost);

        // update tower cost
        towers.tower2.cost = (int)(towers.tower2.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower3()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower3.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower3);
        playerStats.ManageMoney(-towers.tower3.cost);

        // update tower cost
        towers.tower3.cost = (int)(towers.tower3.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower4()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower4.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower4);
        playerStats.ManageMoney(-towers.tower4.cost);

        // update tower cost
        towers.tower4.cost = (int)(towers.tower4.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower5()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower5.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower5);
        playerStats.ManageMoney(-towers.tower5.cost);

        // update tower cost
        towers.tower5.cost = (int)(towers.tower5.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower6()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower6.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower6);
        playerStats.ManageMoney(-towers.tower6.cost);

        // update tower cost
        towers.tower6.cost = (int)(towers.tower6.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower7()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower7.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower7);
        playerStats.ManageMoney(-towers.tower7.cost);

        // update tower cost
        towers.tower7.cost = (int)(towers.tower7.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower8()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower8.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower8);
        playerStats.ManageMoney(-towers.tower8.cost);

        // update tower cost
        towers.tower8.cost = (int)(towers.tower8.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower9()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower9.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower9);
        playerStats.ManageMoney(-towers.tower9.cost);

        // update tower cost
        towers.tower9.cost = (int)(towers.tower9.cost * costMultiplier);
        UpdateTowerCostText();
    }

    public void BuyTower10()
    {
        EventSystem.current.SetSelectedGameObject(null);

        // low money
        if (playerStats.CheckMoney() < towers.tower10.cost)
            return;

        findEmptySlot();

        // slots are full
        if (emptySlot == null)
            return;

        emptySlot.addTowerToSlot(towers.tower10);
        playerStats.ManageMoney(-towers.tower10.cost);

        // update tower cost
        towers.tower10.cost = (int)(towers.tower10.cost * costMultiplier);
        UpdateTowerCostText();
    }

    void findEmptySlot()
    {
        emptySlot = null;

        foreach (Slot s in slotList)
            if (s.empty)
            {
                emptySlot = s;
                return;
            }
    }
}

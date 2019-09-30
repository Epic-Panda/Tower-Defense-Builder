using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{

    public static Towers Instance;

    [Header("Setup")]
    public Tower tower1;
    public Tower tower2, tower3, tower4, tower5, tower6, tower7, tower8, tower9, tower10;
    public int maxLvl = 10;

    public float maxDamage = 0;
    public float maxFirerate = 0;

    [HideInInspector]
    public List<Tower> towerList;

    void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;

        float dps = tower1.fireRate * tower1.damage;

        // tower2 setup
        tower2.cost = (int)(tower1.cost * 2.5);
        tower2.fireRate = 3.2f;
        tower2.damage = dps * 2.1f / tower2.fireRate;
        tower2.earningPerSec = (int)(tower1.earningPerSec * 2.5f);

        // tower3 setup
        dps = tower2.fireRate * tower2.damage;
        tower3.cost = (int)(tower2.cost * 2.5);
        tower3.fireRate = 1.5f;
        tower3.damage = dps * 2.1f / tower3.fireRate;
        tower3.earningPerSec = (int)(tower2.earningPerSec * 2.5f);

        // tower4 setup
        dps = tower3.fireRate * tower3.damage;
        tower4.cost = (int)(tower3.cost * 2.5);
        tower4.fireRate = 3;
        tower4.damage = dps * 2.1f / tower4.fireRate;
        tower4.earningPerSec = (int)(tower3.earningPerSec * 2.5f);

        // tower5 setup
        dps = tower4.fireRate * tower4.damage;
        tower5.cost = (int)(tower4.cost * 2.5);
        tower5.fireRate = 1.2f;
        tower5.damage = dps * 2.1f / tower5.fireRate;
        tower5.earningPerSec = (int)(tower4.earningPerSec * 2.5f);

        // tower6 setup
        dps = tower5.fireRate * tower5.damage;
        tower6.cost = (int)(tower5.cost * 2.5);
        tower6.fireRate = 3.6f;
        tower6.damage = dps * 2.1f / tower6.fireRate;
        tower6.earningPerSec = (int)(tower5.earningPerSec * 2.5f);

        // tower7 setup
        dps = tower6.fireRate * tower6.damage;
        tower7.cost = (int)(tower6.cost * 2.5);
        tower7.fireRate = 2.2f;
        tower7.damage = dps * 2.1f / tower7.fireRate;
        tower7.earningPerSec = (int)(tower6.earningPerSec * 2.5f);

        // tower8 setup
        dps = tower7.fireRate * tower7.damage;
        tower8.cost = (int)(tower7.cost * 2.5);
        tower8.fireRate = 3.8f;
        tower8.damage = dps * 2.1f / tower8.fireRate;
        tower8.earningPerSec = (int)(tower7.earningPerSec * 2.5f);

        // tower9 setup
        dps = tower8.fireRate * tower8.damage;
        tower9.cost = (int)(tower8.cost * 2.5);
        tower9.fireRate = 1.1f;
        tower9.damage = dps * 2.1f / tower9.fireRate;
        tower9.earningPerSec = (int)(tower8.earningPerSec * 2.5f);

        // tower10 setup
        dps = tower9.fireRate * tower9.damage;
        tower10.cost = (int)(tower9.cost * 2.5);
        tower10.fireRate = 3.8f;
        tower10.damage = dps * 2.1f / tower10.fireRate;
        tower10.earningPerSec = (int)(tower9.earningPerSec * 2.5f);


        towerList = new List<Tower>();
        towerList.Add(tower1);
        towerList.Add(tower2);
        towerList.Add(tower3);
        towerList.Add(tower4);
        towerList.Add(tower5);
        towerList.Add(tower6);
        towerList.Add(tower7);
        towerList.Add(tower8);
        towerList.Add(tower9);
        towerList.Add(tower10);

        // find tower max damage and fire rate
        foreach (Tower t in towerList)
        {
            if (t.damage > maxDamage)
                maxDamage = t.damage;

            if (t.fireRate > maxFirerate)
                maxFirerate = t.fireRate;
        }
    }
}

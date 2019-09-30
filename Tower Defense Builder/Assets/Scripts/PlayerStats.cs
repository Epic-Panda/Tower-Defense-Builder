using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField]
    private int money = 500;
    public Text moneyText;
    public Text moneyPerSecText;

    [Header("Moving tower")]
    public TowerInSlot movingTower;
    public Slot selectedSlot;

    int moneyPerSec = 0;
    float timePassed = 0;

    void Awake()
    {
        if (Instance != null)
            return;

        moneyText.text = GetTransformedMoneyText(money);
        moneyPerSecText.text = GetTransformedMoneyText(moneyPerSec);
        Instance = this;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
    }

    public string GetTransformedMoneyText(float amount)
    {
        string s = "$ ";
        string mark = "";

        if (amount >= 1000)
        {
            mark = "k";
            amount /= 1000;
        }

        if (amount >= 1000)
        {
            mark = "m";
            amount /= 1000;
        }

        if (amount >= 1000)
        {
            mark = "g";
            amount /= 1000;
        }

        if (amount >= 1000)
        {
            mark = "aa";
            amount /= 1000;
        }

        if (amount >= 1000)
        {
            mark = "ab";
            amount /= 1000;
        }

        // truncate to 3 decimal
        amount = Mathf.Round(amount * 1000.0f) / 1000.0f;

        return s + amount.ToString() + mark;
    }

    // after kill get money based on time passed since last kill and amount of money per sec
    public void GetMoneyForKill()
    {
        ManageMoney((int)(timePassed * moneyPerSec));
        timePassed = 0;
    }

    public void ManageMoneyPerSec(int amount)
    {
        moneyPerSec += amount;

        if (moneyPerSecText != null)
            moneyPerSecText.text = GetTransformedMoneyText(moneyPerSec);
    }

    public void ManageMoney(int amount)
    {
        money += amount;
        moneyText.text = GetTransformedMoneyText(money);
    }

    public int CheckMoney()
    {
        return money;
    }
}

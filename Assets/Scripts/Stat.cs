using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat{

    public string name;
    public int amount;
    public int minAmount;
    public int maxAmount;
    public Queue<BonusStat> bonusStats = new Queue<BonusStat>();
    public bool calOnTick = false;
    

    public void print()
    {
        Debug.Log(name);
        Debug.Log(amount);
    }
    private void Update()
    {
        if (calOnTick)
            calStatAmount();
    }

    public Stat(string name, int Amount, int minamount,int maxamount)
    {
        this.name = name;
        this.amount = Amount;
        this.minAmount = minamount;
        this.maxAmount = maxamount;
    }

    void calStatAmount()
    {
        foreach (BonusStat i in bonusStats)
        {
            if (i.target == name)
                amount += i.bonusAmount;
            if (amount < minAmount) amount = minAmount;
            if (amount > maxAmount) amount = maxAmount;
        }
    }
    public void addBonusStat(BonusStat bonusStat)
    {
        bonusStats.Enqueue(bonusStat);
        calStatAmount();
    }
    public BonusStat removeBonusStat()
    {
        BonusStat temp = bonusStats.Dequeue();
        calStatAmount();
        return temp;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public List<Stat> stats = new List<Stat>();
    public Queue<BonusStat> buffs = new Queue<BonusStat>();
    public Queue<BonusStat> debuffs = new Queue<BonusStat>();

    public bool updateOnTick = false;
    private void Update()
    {
        if (updateOnTick)
            updateStats();
    }


    public Stat findStatByName(string name)
    {
        foreach (Stat stat in stats)
        {
            if (name == stat.name)
                return stat;
        }
        return null;
    }

    //刷新所有的玩家状态stats，把buff和debuff添加到具体的状态上
    void updateStats()
    {
        foreach (Stat stat in stats)
        {
            foreach (BonusStat buff in buffs)
            {
                if (buff.target == stat.name)
                    stat.addBonusStat(buff);
            }
            foreach (BonusStat debuff in debuffs)
            {
                if (debuff.target == stat.name)
                    stat.addBonusStat(debuff);
            }
        }
    }
    //Damage 和 Restore方法是不可恢复的加减，例如伤害和恢复生命
    public void Damage(int amount,string target)
    {
        foreach (Stat stat in stats)
        {
            if (stat.name == target)
                stat.amount -= amount;
        }
    }
    public void Restore(int amount, string target)
    {
        foreach (Stat stat in stats)
        {
            if (stat.name == target)
                stat.amount += amount;
        }
    }
    //addBuff/removeBuff，addDebuff/removeDebuff用于添加和移除可恢复的状态修改
    public void addBuff(BonusStat buff)
    {
        buffs.Enqueue(buff);
        updateStats();
    }
    public BonusStat removeBuff()
    {
        BonusStat temp =  buffs.Dequeue();
        updateStats();
        return temp;
    }
    public void addDebuff(BonusStat debuff)
    {
        debuffs.Enqueue(debuff);
        updateStats();
    }
    public BonusStat removeDebuff()
    {
        BonusStat temp = debuffs.Dequeue();
        updateStats();
        return temp;
    }

}

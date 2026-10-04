using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
    public List<Stat> stats = new List<Stat>();
    Dictionary<string, float> currStats = new Dictionary<string, float>();

    void Awake()
    {
        //init currStats
        foreach (var stat in stats)
        {
            currStats.Add(stat.statName, stat.value);
        }
    }



    public float GetStat(string name)
    {
        return currStats[name];
    }

    public void SetStat(string name, float val)
    {
        currStats[name] += val;
    }

    public void ApplyItemModifiers(ItemData item)
    {
        foreach (var aStat in item.affectedStats)
        {
            SetStat(aStat.Key,aStat.Value);
        }
    }
}

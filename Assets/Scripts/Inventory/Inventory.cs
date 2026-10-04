using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> inv = new();
    
    public void AddItem(ItemData item)
    {
        inv.Add(item);

        AffectStats(item);
    }

    void AffectStats(ItemData item)
    {
        TryGetComponent<PlayerStat>(out PlayerStat stats);
        stats.ApplyItemModifiers(item);
    }

}

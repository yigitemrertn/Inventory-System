using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "New Item", order = 0)]
public class ItemData : ScriptableObject {
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    
    [SerializeField] public Dictionary<string, float> affectedStats = new();
}

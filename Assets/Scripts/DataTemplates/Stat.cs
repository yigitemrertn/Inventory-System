using UnityEngine;

[CreateAssetMenu(fileName = "Stat", menuName = "New Stat", order = 0)]
public class Stat : ScriptableObject {
    public string statName;
    public float value;
}

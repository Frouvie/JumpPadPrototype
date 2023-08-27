using UnityEngine;

[CreateAssetMenu(menuName = "Chest")]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private int _cost;
    [SerializeField] private GameObject[] _chestLoot;

    public int Cost => this._cost;
    public GameObject[] ChestLoot => this._chestLoot;
}

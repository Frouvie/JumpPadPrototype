using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _startCoins;
    private int _coins;

    private void Start()
    {
        _coins = _startCoins;
    }

    public void AddCoins(int value)
    {
        _coins += value;
    }

    public bool DescreaseCoins(int value)
    {
        bool isEnough = _coins >= value;
        if (isEnough)
            _coins -= value;

        return isEnough;
    }
}

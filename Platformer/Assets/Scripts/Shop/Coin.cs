using UnityEngine;

public class Coin : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    [SerializeField] private int _coinValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            PlayerWallet wallet = other.GetComponent<PlayerWallet>();
            OnPicked(wallet);
        }
    }

    private void OnPicked(PlayerWallet wallet)
    {
        wallet.AddCoins(_coinValue);
        Destroy(gameObject);
    }
}

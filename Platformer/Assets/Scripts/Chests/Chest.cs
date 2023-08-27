using UnityEngine;

public class Chest : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private const string IS_OPENED_TRIGGER = "IsOpened";

    [SerializeField] private ChestInfo _chestInfo;
    [SerializeField] private Transform _itemHolder;
    [SerializeField] private Animator _animator;
    bool _isBought = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isBought) return;

        if (other.CompareTag(PLAYER_TAG))
        {
            PlayerWallet wallet = other.GetComponent<PlayerWallet>();

            if (wallet == null) return;

            _isBought = wallet.DescreaseCoins(_chestInfo.Cost);

            if (_isBought)
            {
                _animator.SetTrigger(IS_OPENED_TRIGGER);
            }
        }
    }

    private void GenerateDrop()
    {
        int variantsLength = _chestInfo.ChestLoot.Length;
        int randomIndex = Random.Range(0, variantsLength);

        Instantiate(_chestInfo.ChestLoot[randomIndex], _itemHolder.position, Quaternion.identity);
    }
}

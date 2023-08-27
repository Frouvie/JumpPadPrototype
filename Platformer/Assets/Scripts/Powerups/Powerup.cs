using UnityEngine;

public class Powerup : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    [SerializeField] private PowerupEffect _powerupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            ApplyPowerup(other.gameObject);
        }
    }

    private void ApplyPowerup(GameObject player)
    {
        Destroy(gameObject);
        _powerupEffect.Apply(player);
    }
}

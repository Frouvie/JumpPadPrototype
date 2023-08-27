using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    protected const string PLAYER_TAG = "Player";

    protected Rigidbody2D rb;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int auraDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            HitPlayerOnCollision(other.gameObject);
        }
    }
    
    private void HitPlayerOnCollision(GameObject player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.TakeDamage(auraDamage);
    }
}
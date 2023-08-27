using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage % health;

        if (health <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {

    }

    public virtual void IncreaseHealth(int value)
    {
        health += value % maxHealth;
    }
}

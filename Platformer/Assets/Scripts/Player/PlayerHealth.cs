using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private HealthBar _healthBar;

    protected override void Start()
    {
        base.Start();
        _healthBar.SetMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _healthBar.SetHealth(health);
    }

    public override void Kill()
    {

    }

    public override void IncreaseHealth(int value)
    {
        base.IncreaseHealth(value);
        _healthBar.SetHealth(health);
    }
}

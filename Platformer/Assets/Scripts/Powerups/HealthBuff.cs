using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Health Buff")]
public class HealthBuff : PowerupEffect
{
    [SerializeField] private int _amount;

    public override void Apply(GameObject player)
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.IncreaseHealth(_amount);
    }
}

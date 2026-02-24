using UnityEngine;

public class EnemySwarm : Enemy
{
    protected override void Start()
    {
      base.Start();
      health *= 1f;    
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount * 0.1f);
    }

    
}

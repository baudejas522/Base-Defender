using UnityEngine;

public class EnemyTank : Enemy
{
    protected override void Start()
    {
        base.Start();
        health *= 2f;
    }

    
    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount * 0.7f);
    }
}

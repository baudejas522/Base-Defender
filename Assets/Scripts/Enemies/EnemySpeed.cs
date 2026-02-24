using UnityEngine;

public class EnemySpeed : Enemy
{
    protected override void Start()
    {
        base.Start();
        speed *= 2f;
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount * 50f);
    }
}

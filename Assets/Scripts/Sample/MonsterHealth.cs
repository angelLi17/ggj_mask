using UnityEngine;

public class MonsterHealth : Health
{
    public int killPoints = 50;

    protected override void Die()
    {
        base.Die();

        ScoreSystem.instance.AddPoints(killPoints);
        Destroy(gameObject);
    }
}
using UnityEngine;

public class Bat : Mob
{
    protected override void Start()
    {
        base.Start();
        maxHealth = 5f;
        attackDamage = 0f;
        attackRange = 0f;
        detectionRange = 15f;
        moveSpeed = 7f;
        isAggressive = false;
        isNocturnal = true;
    }

    protected override void Wander()
    {
        base.Wander();
        // Logique de vol
    }

    protected override void DropLoot()
    {
        // Pas de loot
    }
}

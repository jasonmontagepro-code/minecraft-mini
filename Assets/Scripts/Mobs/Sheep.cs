using UnityEngine;

public class Sheep : Mob
{
    protected override void Start()
    {
        base.Start();
        maxHealth = 8f;
        attackDamage = 0f;
        attackRange = 0f;
        detectionRange = 12f;
        moveSpeed = 3.5f;
        isAggressive = false;
        isNocturnal = false;
    }

    protected override void DropLoot()
    {
        Debug.Log("Mouton a lâché de la laine !");
    }
}

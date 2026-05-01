using UnityEngine;

public class Pig : Mob
{
    protected override void Start()
    {
        base.Start();
        maxHealth = 10f;
        attackDamage = 0f;
        attackRange = 0f;
        detectionRange = 15f;
        moveSpeed = 4f;
        isAggressive = false;
        isNocturnal = false;
    }

    protected override void DropLoot()
    {
        Debug.Log("Cochon a lâché du jambon !");
    }
}

using UnityEngine;

public class Skeleton : Mob
{
    [SerializeField] private float shootCooldown = 1f;
    private float lastShootTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 20f;
        attackDamage = 2.5f;
        attackRange = 15f;
        detectionRange = 30f;
        moveSpeed = 4f;
        isAggressive = true;
        isNocturnal = true;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastShootTime > shootCooldown)
        {
            // Tirer une flèche
            base.AttackPlayer();
            lastShootTime = Time.time;
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Squelette a lâché des flèches !");
    }
}

using UnityEngine;

public class Swordsman : Mob
{
    [SerializeField] private float slashCooldown = 1f;
    private float lastSlashTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 35f;
        attackDamage = 3f;
        attackRange = 2.5f;
        detectionRange = 25f;
        moveSpeed = 5.5f;
        isAggressive = true;
        isNocturnal = true;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastSlashTime > slashCooldown)
        {
            base.AttackPlayer();
            lastSlashTime = Time.time;
            Debug.Log("Épéiste frappe !");
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Épéiste a lâché une épée !");
    }
}

using UnityEngine;

public class Miner : Mob
{
    [SerializeField] private float pickaxeAttackCooldown = 1.2f;
    private float lastAttackTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 25f;
        attackDamage = 2.5f;
        attackRange = 2f;
        detectionRange = 20f;
        moveSpeed = 4f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastAttackTime > pickaxeAttackCooldown)
        {
            base.AttackPlayer();
            lastAttackTime = Time.time;
            Debug.Log("Mineur frappe avec sa pioche !");
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Mineur a lâché un minerai !");
    }
}

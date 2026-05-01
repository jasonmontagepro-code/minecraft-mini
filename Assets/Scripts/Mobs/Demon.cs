using UnityEngine;

public class Demon : Mob
{
    [SerializeField] private float infernalAttackCooldown = 1.5f;
    private float lastAttackTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 50f;
        attackDamage = 4.5f;
        attackRange = 3f;
        detectionRange = 30f;
        moveSpeed = 6f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastAttackTime > infernalAttackCooldown)
        {
            base.AttackPlayer();
            lastAttackTime = Time.time;
            Debug.Log("Démon attaque !");
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Démon a lâché une âme !");
    }
}

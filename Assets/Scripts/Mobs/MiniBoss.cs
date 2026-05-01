using UnityEngine;

public class MiniBoss : Mob
{
    [SerializeField] private float phase2HealthThreshold = 50f;
    [SerializeField] private float superAttackCooldown = 3f;
    private float lastSuperAttackTime = 0f;
    private bool isPhase2 = false;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 150f;
        attackDamage = 3.5f;
        attackRange = 3f;
        detectionRange = 40f;
        moveSpeed = 5f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void Update()
    {
        base.Update();
        
        if (currentHealth < phase2HealthThreshold && !isPhase2)
        {
            isPhase2 = true;
            attackDamage *= 1.5f;
            moveSpeed *= 1.3f;
            Debug.Log("Mini Boss passe en phase 2 !");
        }
    }

    protected override void AttackPlayer()
    {
        if (isPhase2 && Time.time - lastSuperAttackTime > superAttackCooldown)
        {
            base.AttackPlayer();
            base.AttackPlayer();
            base.AttackPlayer();
            lastSuperAttackTime = Time.time;
            Debug.Log("Mini Boss attaque spéciale !");
        }
        else
        {
            base.AttackPlayer();
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Mini Boss a lâché un trésor légendaire !");
    }
}

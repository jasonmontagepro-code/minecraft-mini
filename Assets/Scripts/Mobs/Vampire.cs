using UnityEngine;

public class Vampire : Mob
{
    [SerializeField] private float healAmount = 2f;
    [SerializeField] private float teleportRange = 5f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 40f;
        attackDamage = 4f;
        attackRange = 2f;
        detectionRange = 30f;
        moveSpeed = 6f;
        isAggressive = true;
        isNocturnal = true;
    }

    protected override void AttackPlayer()
    {
        base.AttackPlayer();
        // Vampirisme - régénération
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }

    protected override void DropLoot()
    {
        Debug.Log("Vampire a lâché un cristal de vie !");
    }
}

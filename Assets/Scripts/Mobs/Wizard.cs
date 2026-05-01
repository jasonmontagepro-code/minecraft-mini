using UnityEngine;

public class Wizard : Mob
{
    [SerializeField] private float spellCooldown = 2f;
    private float lastSpellTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 30f;
        attackDamage = 3.5f;
        attackRange = 20f;
        detectionRange = 35f;
        moveSpeed = 4f;
        isAggressive = true;
        isNocturnal = true;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastSpellTime > spellCooldown)
        {
            base.AttackPlayer();
            lastSpellTime = Time.time;
            Debug.Log("Sorcier lance un sort !");
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Sorcier a lâché un bâton magique !");
    }
}

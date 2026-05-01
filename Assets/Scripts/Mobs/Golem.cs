using UnityEngine;

public class Golem : Mob
{
    [SerializeField] private float stoneSkinDefense = 0.5f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 100f;
        attackDamage = 5f;
        attackRange = 2.5f;
        detectionRange = 25f;
        moveSpeed = 2f;
        isAggressive = true;
        isNocturnal = false;
    }

    public override void TakeDamage(float damage)
    {
        // Réduit les dégâts grâce à la peau de pierre
        base.TakeDamage(damage * stoneSkinDefense);
    }

    protected override void DropLoot()
    {
        Debug.Log("Golem a lâché une pierre précieuse !");
    }
}

using UnityEngine;

public class Spider : Mob
{
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float climbSpeed = 8f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 16f;
        attackDamage = 2f;
        attackRange = 2.5f;
        detectionRange = 25f;
        moveSpeed = 6f;
        isAggressive = true;
        isNocturnal = true;
    }

    protected override void ChasePlayer()
    {
        base.ChasePlayer();
        // Logique de saut/escalade
    }

    protected override void DropLoot()
    {
        Debug.Log("Araignée a lâché de la soie !");
    }
}

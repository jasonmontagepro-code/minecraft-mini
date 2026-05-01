using UnityEngine;

public class Horse : Mob
{
    [SerializeField] private float gallop speed = 12f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 30f;
        attackDamage = 0f;
        attackRange = 0f;
        detectionRange = 20f;
        moveSpeed = 8f;
        isAggressive = false;
        isNocturnal = false;
    }

    protected override void DropLoot()
    {
        Debug.Log("Cheval a lâché du cuir !");
    }
}

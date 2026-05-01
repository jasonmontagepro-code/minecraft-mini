using UnityEngine;

public class GiantWorm : Mob
{
    [SerializeField] private float segmentCount = 5f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 60f;
        attackDamage = 3f;
        attackRange = 2.5f;
        detectionRange = 20f;
        moveSpeed = 4f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void DropLoot()
    {
        Debug.Log("Ver géant a lâché de la terre fertile !");
    }
}

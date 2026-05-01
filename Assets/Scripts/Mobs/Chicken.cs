using UnityEngine;

public class Chicken : Mob
{
    [SerializeField] private float flutterHeight = 2f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 4f;
        attackDamage = 0f;
        attackRange = 0f;
        detectionRange = 10f;
        moveSpeed = 3f;
        isAggressive = false;
        isNocturnal = false;
    }

    protected override void DropLoot()
    {
        Debug.Log("Poule a lâché un oeuf !");
    }
}

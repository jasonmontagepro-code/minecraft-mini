using UnityEngine;

public class Zombie : Mob
{
    [SerializeField] private float spawnItemChance = 0.5f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 20f;
        attackDamage = 2f;
        attackRange = 2f;
        detectionRange = 30f;
        moveSpeed = 3f;
        isAggressive = true;
        isNocturnal = true;
    }

    protected override void DropLoot()
    {
        if (Random.value < spawnItemChance)
        {
            Debug.Log("Zombie a lâché de la viande !");
            // Instancier item de viande
        }
    }
}

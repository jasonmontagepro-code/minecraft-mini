using UnityEngine;

public class Fairy : Mob
{
    [SerializeField] private float healingRadius = 10f;
    [SerializeField] private float healingAmount = 1f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 8f;
        attackDamage = 0.5f;
        attackRange = 1.5f;
        detectionRange = 15f;
        moveSpeed = 7f;
        isAggressive = false;
        isNocturnal = false;
    }

    protected override void Update()
    {
        base.Update();
        HealNearbyMobs();
    }

    private void HealNearbyMobs()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, healingRadius);
        
        foreach (Collider collider in colliders)
        {
            Mob mob = collider.GetComponent<Mob>();
            if (mob != null && mob != this && mob.GetHealth() < mob.GetMaxHealth())
            {
                // Soigner le mob
            }
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Fée a lâché de la poudre magique !");
    }
}

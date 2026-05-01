using UnityEngine;

public class Cow : Mob
{
    protected override void Start()
    {
        base.Start();
        maxHealth = 10f;
        attackDamage = 0f;
        attackRange = 0f;
        detectionRange = 15f;
        moveSpeed = 4f;
        isAggressive = false;
        isNocturnal = false;
    }

    protected override void ChasePlayer()
    {
        // Fuir au lieu de chasser
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            Vector3 fleeDirection = (transform.position - playerTransform.position).normalized;
            navAgent.SetDestination(transform.position + fleeDirection * 20f);
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Vache a lâché de la viande crue !");
    }
}

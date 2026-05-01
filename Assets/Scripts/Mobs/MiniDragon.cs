using UnityEngine;

public class MiniDragon : Mob
{
    [SerializeField] private float firebreathCooldown = 2f;
    [SerializeField] private float firebreathRange = 15f;
    private float lastFirebreathTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 80f;
        attackDamage = 4f;
        attackRange = 3f;
        detectionRange = 35f;
        moveSpeed = 7f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastFirebreathTime > firebreathCooldown)
        {
            Firebreath();
        }
        else
        {
            base.AttackPlayer();
        }
    }

    private void Firebreath()
    {
        Debug.Log("Mini Dragon crache du feu !");
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, firebreathRange);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerStats playerStats = collider.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(5f);
                }
            }
        }
        
        lastFirebreathTime = Time.time;
    }

    protected override void DropLoot()
    {
        Debug.Log("Mini Dragon a lâché une écaille de dragon !");
    }
}

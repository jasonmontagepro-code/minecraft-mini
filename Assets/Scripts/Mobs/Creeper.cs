using UnityEngine;

public class Creeper : Mob
{
    [SerializeField] private float explosionRadius = 10f;
    [SerializeField] private float explosionForce = 500f;
    [SerializeField] private float fuseTime = 1.5f;
    private float fuseTimer = 0f;
    private bool isExploding = false;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 20f;
        attackDamage = 0f;
        attackRange = 3f;
        detectionRange = 25f;
        moveSpeed = 5f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void Update()
    {
        base.Update();
        
        if (isExploding)
        {
            fuseTimer += Time.deltaTime;
            if (fuseTimer >= fuseTime)
            {
                Explode();
            }
        }
    }

    protected override void AttackPlayer()
    {
        if (!isExploding)
        {
            isExploding = true;
            Debug.Log("Creeper explose !");
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerStats playerStats = collider.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(10f);
                }
            }
            
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        
        isAlive = false;
        Destroy(gameObject);
    }
}

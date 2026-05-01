using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 10f;
    [SerializeField] protected float attackDamage = 1f;
    [SerializeField] protected float attackRange = 2f;
    [SerializeField] protected float detectionRange = 20f;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected bool isAggressive = true;
    [SerializeField] protected bool isNocturnal = false;
    
    protected float currentHealth;
    protected Transform playerTransform;
    protected Rigidbody rb;
    protected NavMeshAgent navAgent;
    protected bool isAlive = true;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();
        
        Transform playerObj = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (playerObj != null)
            playerTransform = playerObj;
    }

    protected virtual void Update()
    {
        if (!isAlive) return;

        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            
            if (distanceToPlayer < detectionRange)
            {
                if (isAggressive)
                {
                    ChasePlayer();
                    
                    if (distanceToPlayer < attackRange)
                    {
                        AttackPlayer();
                    }
                }
            }
            else
            {
                Wander();
            }
        }
    }

    protected virtual void ChasePlayer()
    {
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            navAgent.SetDestination(playerTransform.position);
        }
    }

    protected virtual void Wander()
    {
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            if (!navAgent.hasPath || navAgent.remainingDistance < 1f)
            {
                Vector3 randomPoint = transform.position + Random.insideUnitSphere * 10f;
                navAgent.SetDestination(randomPoint);
            }
        }
    }

    protected virtual void AttackPlayer()
    {
        PlayerStats playerStats = playerTransform.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.TakeDamage(attackDamage * Time.deltaTime);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} prend {damage} dégâts. Santé: {currentHealth}");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        isAlive = false;
        DropLoot();
        Destroy(gameObject);
    }

    protected virtual void DropLoot()
    {
        // À personnaliser pour chaque mob
    }

    public float GetHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
}

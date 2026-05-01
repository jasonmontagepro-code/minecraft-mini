using UnityEngine;

public class Enderman : Mob
{
    [SerializeField] private float teleportRange = 8f;
    [SerializeField] private float teleportCooldown = 3f;
    private float lastTeleportTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 40f;
        attackDamage = 3f;
        attackRange = 3f;
        detectionRange = 30f;
        moveSpeed = 5f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void ChasePlayer()
    {
        base.ChasePlayer();
        
        if (Time.time - lastTeleportTime > teleportCooldown)
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        Vector3 randomPoint = playerTransform.position + Random.insideUnitSphere * teleportRange;
        transform.position = randomPoint;
        lastTeleportTime = Time.time;
        Debug.Log("Enderman se téléporte !");
    }

    protected override void DropLoot()
    {
        Debug.Log("Enderman a lâché une perle !");
    }
}

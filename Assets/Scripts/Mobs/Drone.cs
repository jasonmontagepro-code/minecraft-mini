using UnityEngine;

public class Drone : Mob
{
    [SerializeField] private float laserCooldown = 1.5f;
    private float lastLaserTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 25f;
        attackDamage = 2.5f;
        attackRange = 20f;
        detectionRange = 30f;
        moveSpeed = 8f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void AttackPlayer()
    {
        if (Time.time - lastLaserTime > laserCooldown)
        {
            base.AttackPlayer();
            lastLaserTime = Time.time;
            Debug.Log("Drone tire un laser !");
        }
    }

    protected override void DropLoot()
    {
        Debug.Log("Drone a lâché un circuit !");
    }
}

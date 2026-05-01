using UnityEngine;

public class Ghast : Mob
{
    [SerializeField] private float floatHeight = 5f;
    [SerializeField] private float fireballCooldown = 2f;
    private float lastFireballTime = 0f;
    
    protected override void Start()
    {
        base.Start();
        maxHealth = 50f;
        attackDamage = 4f;
        attackRange = 25f;
        detectionRange = 40f;
        moveSpeed = 3f;
        isAggressive = true;
        isNocturnal = false;
    }

    protected override void ChasePlayer()
    {
        base.ChasePlayer();
        
        if (Time.time - lastFireballTime > fireballCooldown)
        {
            ShootFireball();
        }
    }

    private void ShootFireball()
    {
        Debug.Log("Ghast lance une boule de feu !");
        lastFireballTime = Time.time;
    }

    protected override void DropLoot()
    {
        Debug.Log("Ghast a lâché de la poudre !");
    }
}

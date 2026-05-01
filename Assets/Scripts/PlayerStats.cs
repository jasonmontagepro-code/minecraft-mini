using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] private float maxHunger = 100f;
    [SerializeField] private float hungerDecayRate = 0.1f;
    [SerializeField] private float sprintHungerCost = 0.5f;
    
    private float currentHealth;
    private float currentHunger;
    private bool isSprinting = false;
    private bool isCrouching = false;
    private float moveSpeed = 10f;
    private float sprintSpeed = 15f;
    private float crouchSpeed = 5f;

    private void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
    }

    private void Update()
    {
        HandleSprint();
        HandleCrouch();
        UpdateHunger();
    }

    private void HandleSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && currentHunger > 0)
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        if (isSprinting && currentHunger > 0)
        {
            currentHunger -= sprintHungerCost * Time.deltaTime;
        }
    }

    private void HandleCrouch()
    {
        isCrouching = Input.GetKey(KeyCode.LeftControl);
    }

    private void UpdateHunger()
    {
        currentHunger -= hungerDecayRate * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

        if (currentHunger <= 0)
        {
            TakeDamage(0.1f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Joueur prend {damage} dégâts. Santé: {currentHealth}");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public void Eat(float hungerRestore)
    {
        currentHunger = Mathf.Clamp(currentHunger + hungerRestore, 0, maxHunger);
    }

    public float GetCurrentSpeed()
    {
        if (isSprinting && currentHunger > 0)
            return sprintSpeed;
        if (isCrouching)
            return crouchSpeed;
        return moveSpeed;
    }

    public bool IsSprinting() => isSprinting && currentHunger > 0;
    public bool IsCrouching() => isCrouching;
    public float GetHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
    public float GetHunger() => currentHunger;
    public float GetMaxHunger() => maxHunger;

    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        // Respawn ou game over
    }
}

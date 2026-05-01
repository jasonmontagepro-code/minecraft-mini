using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image hungerBar;
    [SerializeField] private Text healthText;
    [SerializeField] private Text hungerText;
    
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        if (playerStats != null)
        {
            // Mise à jour des barres
            healthBar.fillAmount = playerStats.GetHealth() / playerStats.GetMaxHealth();
            hungerBar.fillAmount = playerStats.GetHunger() / playerStats.GetMaxHunger();

            // Mise à jour des textes
            healthText.text = $"Santé: {playerStats.GetHealth():F1} / {playerStats.GetMaxHealth()}";
            hungerText.text = $"Faim: {playerStats.GetHunger():F1} / {playerStats.GetMaxHunger()}";

            // Changer couleur selon la santé
            if (playerStats.GetHealth() < 5)
                healthBar.color = Color.red;
            else if (playerStats.GetHealth() < 10)
                healthBar.color = Color.yellow;
            else
                healthBar.color = Color.green;
        }
    }
}

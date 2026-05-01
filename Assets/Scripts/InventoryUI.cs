using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private GameObject itemSlotPrefab;
    
    private Dictionary<BlockType, int> inventory = new Dictionary<BlockType, int>();
    private BlockType selectedBlock = BlockType.Dirt;
    private bool inventoryOpen = false;

    private void Start()
    {
        // Inventaire de départ
        inventory[BlockType.Dirt] = 64;
        inventory[BlockType.Wood] = 32;
        inventory[BlockType.Stone] = 32;
        inventory[BlockType.Grass] = 16;
        
        if (inventoryPanel != null)
            inventoryPanel.SetActive(false);
        
        UpdateInventoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        // Sélection rapide avec les touches 1-9
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SelectSlot(i);
            }
        }
    }

    public void AddItem(BlockType type, int amount)
    {
        if (!inventory.ContainsKey(type))
            inventory[type] = 0;
        
        inventory[type] += amount;
        UpdateInventoryUI();
    }

    public bool UseItem(BlockType type, int amount)
    {
        if (inventory.ContainsKey(type) && inventory[type] >= amount)
        {
            inventory[type] -= amount;
            UpdateInventoryUI();
            return true;
        }
        return false;
    }

    public BlockType GetSelectedBlock()
    {
        return selectedBlock;
    }

    private void SelectSlot(int slot)
    {
        selectedBlock = BlockType.Dirt; // À améliorer
    }

    private void ToggleInventory()
    {
        inventoryOpen = !inventoryOpen;
        if (inventoryPanel != null)
            inventoryPanel.SetActive(inventoryOpen);
    }

    private void UpdateInventoryUI()
    {
        if (inventoryContent != null)
        {
            foreach (Transform child in inventoryContent)
            {
                Destroy(child.gameObject);
            }

            foreach (var item in inventory)
            {
                if (item.Value > 0)
                {
                    GameObject slot = Instantiate(itemSlotPrefab, inventoryContent);
                    TextMeshProUGUI text = slot.GetComponentInChildren<TextMeshProUGUI>();
                    if (text != null)
                    {
                        text.text = $"{item.Key}: {item.Value}";
                    }
                }
            }
        }
    }
}

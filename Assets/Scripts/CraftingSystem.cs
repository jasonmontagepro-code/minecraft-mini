using UnityEngine;
using System.Collections.Generic;

public class CraftingSystem : MonoBehaviour
{
    private InventoryUI inventoryUI;
    private Dictionary<BlockType, BlockType> craftingRecipes;

    private void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
        InitializeRecipes();
    }

    private void InitializeRecipes()
    {
        craftingRecipes = new Dictionary<BlockType, BlockType>
        {
            { BlockType.Wood, BlockType.Planks },
            { BlockType.Stone, BlockType.Cobblestone }
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            OpenCraftingMenu();
        }
    }

    private void OpenCraftingMenu()
    {
        Debug.Log("Menu de crafting ouvert.");
        // À implémenter : UI de crafting
    }

    public bool CraftItem(BlockType input, BlockType output)
    {
        if (inventoryUI.UseItem(input, 1))
        {
            inventoryUI.AddItem(output, 1);
            return true;
        }
        return false;
    }
}

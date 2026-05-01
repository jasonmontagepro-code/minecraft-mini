using UnityEngine;

public class BlockPlacement : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 5f;
    [SerializeField] private Camera playerCamera;
    
    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DestroyBlock();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            PlaceBlock();
        }
    }

    private void DestroyBlock()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, raycastDistance))
        {
            Block block = hit.collider.GetComponent<Block>();
            if (block != null && block.blockType != BlockType.Obsidian)
            {
                Vector3Int gridPos = block.gridPosition;
                WorldManager.instance.SetBlock(gridPos.x, gridPos.y, gridPos.z, BlockType.Air);
                
                // Ajouter à l'inventaire
                if (inventoryUI != null)
                {
                    inventoryUI.AddItem(block.blockType, 1);
                }
            }
        }
    }

    private void PlaceBlock()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, raycastDistance))
        {
            Vector3 placePos = hit.point + hit.normal * 0.5f;
            Vector3Int gridPos = Vector3Int.FloorToInt(placePos);

            BlockType selectedBlock = inventoryUI?.GetSelectedBlock() ?? BlockType.Dirt;
            
            if (inventoryUI != null && inventoryUI.UseItem(selectedBlock, 1))
            {
                WorldManager.instance.SetBlock(gridPos.x, gridPos.y, gridPos.z, selectedBlock);
            }
        }
    }
}

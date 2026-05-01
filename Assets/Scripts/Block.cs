using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockType blockType;
    public Vector3Int gridPosition;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    public void Initialize(BlockType type, Vector3Int pos)
    {
        blockType = type;
        gridPosition = pos;
        
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        
        UpdateBlock();
    }

    public void UpdateBlock()
    {
        // Mise à jour de la couleur
        if (meshRenderer != null)
        {
            Material mat = meshRenderer.material;
            mat.color = BlockTypeManager.GetColor(blockType);
        }

        // Activer/désactiver le collider
        if (meshCollider != null)
        {
            meshCollider.enabled = BlockTypeManager.IsSolid(blockType);
        }
    }

    public void SetBlockType(BlockType newType)
    {
        blockType = newType;
        UpdateBlock();
    }
}

using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Air,
    Grass,
    Dirt,
    Stone,
    Wood,
    Leaves,
    Planks,
    Cobblestone,
    Sand,
    Water,
    Obsidian,
    Crafting,
    Furnace
}

public class BlockTypeManager : MonoBehaviour
{
    private static Dictionary<BlockType, Color> blockColors = new Dictionary<BlockType, Color>()
    {
        { BlockType.Air, Color.clear },
        { BlockType.Grass, new Color(0.2f, 0.8f, 0.2f) },
        { BlockType.Dirt, new Color(0.6f, 0.4f, 0.2f) },
        { BlockType.Stone, new Color(0.5f, 0.5f, 0.5f) },
        { BlockType.Wood, new Color(0.4f, 0.2f, 0.1f) },
        { BlockType.Leaves, new Color(0.1f, 0.6f, 0.1f) },
        { BlockType.Planks, new Color(0.6f, 0.4f, 0.1f) },
        { BlockType.Cobblestone, new Color(0.4f, 0.4f, 0.4f) },
        { BlockType.Sand, new Color(0.9f, 0.8f, 0.3f) },
        { BlockType.Water, new Color(0.3f, 0.5f, 0.9f) },
        { BlockType.Obsidian, new Color(0.1f, 0.05f, 0.2f) },
        { BlockType.Crafting, new Color(0.7f, 0.5f, 0.2f) },
        { BlockType.Furnace, new Color(0.3f, 0.3f, 0.3f) }
    };

    public static Color GetColor(BlockType type)
    {
        if (blockColors.ContainsKey(type))
            return blockColors[type];
        return Color.white;
    }

    public static bool IsSolid(BlockType type)
    {
        return type != BlockType.Air && type != BlockType.Water;
    }

    public static bool IsTransparent(BlockType type)
    {
        return type == BlockType.Air || type == BlockType.Water || type == BlockType.Leaves;
    }
}

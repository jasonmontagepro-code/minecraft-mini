using UnityEngine;
using System.Collections.Generic;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;
    
    [SerializeField] private int worldWidth = 64;
    [SerializeField] private int worldHeight = 64;
    [SerializeField] private int worldDepth = 64;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Material blockMaterial;
    
    private BlockType[,,] blocks;
    private Dictionary<Vector3Int, GameObject> blockGameObjects = new Dictionary<Vector3Int, GameObject>();
    private Transform blocksContainer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        blocksContainer = new GameObject("Blocks").transform;
        InitializeWorld();
    }

    private void InitializeWorld()
    {
        blocks = new BlockType[worldWidth, worldHeight, worldDepth];
        
        // Remplir le monde
        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                for (int z = 0; z < worldDepth; z++)
                {
                    if (y == 0)
                        blocks[x, y, z] = BlockType.Stone;
                    else if (y < 5)
                        blocks[x, y, z] = BlockType.Dirt;
                    else if (y < 20)
                        blocks[x, y, z] = BlockType.Air;
                    else if (y < 30)
                        blocks[x, y, z] = BlockType.Grass;
                    else
                        blocks[x, y, z] = BlockType.Air;
                }
            }
        }

        // Créer quelques arbres
        CreateTrees();
        
        // Créer une grotte avec portail de l'End
        CreateCave();
        
        // Générer les GameObjects des blocs
        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldHeight; y++)
            {
                for (int z = 0; z < worldDepth; z++)
                {
                    if (blocks[x, y, z] != BlockType.Air)
                    {
                        CreateBlockGameObject(x, y, z, blocks[x, y, z]);
                    }
                }
            }
        }
    }

    private void CreateTrees()
    {
        // Créer quelques arbres simples
        int[] treePositions = { 10, 20, 30, 40, 50 };
        
        foreach (int x in treePositions)
        {
            foreach (int z in treePositions)
            {
                int treeHeight = Random.Range(5, 8);
                int treeY = 21;
                
                // Tronc
                for (int i = 0; i < treeHeight; i++)
                {
                    blocks[x, treeY + i, z] = BlockType.Wood;
                }
                
                // Feuilles
                int leafRadius = 3;
                for (int lx = -leafRadius; lx <= leafRadius; lx++)
                {
                    for (int lz = -leafRadius; lz <= leafRadius; lz++)
                    {
                        for (int ly = 0; ly < 4; ly++)
                        {
                            int leafY = treeY + treeHeight - 1 + ly;
                            int leafX = x + lx;
                            int leafZ = z + lz;
                            
                            if (IsInBounds(leafX, leafY, leafZ) && blocks[leafX, leafY, leafZ] == BlockType.Air)
                            {
                                blocks[leafX, leafY, leafZ] = BlockType.Leaves;
                            }
                        }
                    }
                }
            }
        }
    }

    private void CreateCave()
    {
        // Grotte simple au centre du monde
        int caveX = 32;
        int caveZ = 32;
        int caveY = 15;
        int caveRadius = 8;

        // Creuser la grotte
        for (int x = caveX - caveRadius; x <= caveX + caveRadius; x++)
        {
            for (int y = caveY - 3; y <= caveY + 5; y++)
            {
                for (int z = caveZ - caveRadius; z <= caveZ + caveRadius; z++)
                {
                    if (IsInBounds(x, y, z))
                    {
                        float distance = Vector3.Distance(new Vector3(x, y, z), new Vector3(caveX, caveY, caveZ));
                        if (distance < caveRadius)
                        {
                            blocks[x, y, z] = BlockType.Air;
                        }
                    }
                }
            }
        }

        // Placer le portail de l'End au fond de la grotte
        PlaceEndPortal(caveX, caveY - 5, caveZ);
    }

    private void PlaceEndPortal(int centerX, int centerY, int centerZ)
    {
        // Portail 5x4 en obsidienne avec cadre de blocs obsidienne
        int portalWidth = 5;
        int portalHeight = 4;

        // Cadre extérieur (3x3 blocs avec vide au centre)
        for (int y = 0; y < portalHeight; y++)
        {
            for (int x = -2; x <= 2; x++)
            {
                for (int z = -2; z <= 2; z++)
                {
                    int posX = centerX + x;
                    int posY = centerY + y;
                    int posZ = centerZ + z;

                    if (IsInBounds(posX, posY, posZ))
                    {
                        // Bordure en obsidienne
                        if (x == -2 || x == 2 || y == 0 || y == portalHeight - 1 || z == -2 || z == 2)
                        {
                            blocks[posX, posY, posZ] = BlockType.Obsidian;
                        }
                        else
                        {
                            blocks[posX, posY, posZ] = BlockType.Air;
                        }
                    }
                }
            }
        }
    }

    private void CreateBlockGameObject(int x, int y, int z, BlockType type)
    {
        Vector3Int gridPos = new Vector3Int(x, y, z);
        
        GameObject blockObj = Instantiate(blockPrefab, new Vector3(x, y, z), Quaternion.identity, blocksContainer);
        blockObj.name = $"Block_{x}_{y}_{z}";
        
        Block blockScript = blockObj.GetComponent<Block>();
        if (blockScript == null)
            blockScript = blockObj.AddComponent<Block>();
        
        blockScript.Initialize(type, gridPos);
        blockGameObjects[gridPos] = blockObj;
    }

    public BlockType GetBlock(int x, int y, int z)
    {
        if (IsInBounds(x, y, z))
            return blocks[x, y, z];
        return BlockType.Air;
    }

    public void SetBlock(int x, int y, int z, BlockType type)
    {
        if (!IsInBounds(x, y, z)) return;

        blocks[x, y, z] = type;
        Vector3Int gridPos = new Vector3Int(x, y, z);

        if (blockGameObjects.ContainsKey(gridPos))
        {
            Destroy(blockGameObjects[gridPos]);
            blockGameObjects.Remove(gridPos);
        }

        if (type != BlockType.Air)
        {
            CreateBlockGameObject(x, y, z, type);
        }
    }

    private bool IsInBounds(int x, int y, int z)
    {
        return x >= 0 && x < worldWidth && y >= 0 && y < worldHeight && z >= 0 && z < worldDepth;
    }
}

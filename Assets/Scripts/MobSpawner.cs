using UnityEngine;
using System.Collections.Generic;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private int maxMobCount = 50;
    [SerializeField] private float spawnRadius = 50f;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private Transform playerTransform;
    
    private float lastSpawnTime = 0f;
    private List<GameObject> activeMobs = new List<GameObject>();
    
    private List<GameObject> mobPrefabs = new List<GameObject>();

    private void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime > spawnCooldown && activeMobs.Count < maxMobCount)
        {
            SpawnRandomMob();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnRandomMob()
    {
        if (playerTransform == null) return;

        Vector3 spawnPos = playerTransform.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = 35f; // Au-dessus du sol

        // Créer les mobs directement
        int mobType = Random.Range(0, 25);
        GameObject mobInstance = null;

        switch (mobType)
        {
            case 0: mobInstance = new GameObject("Zombie"); mobInstance.AddComponent<Zombie>(); break;
            case 1: mobInstance = new GameObject("Spider"); mobInstance.AddComponent<Spider>(); break;
            case 2: mobInstance = new GameObject("Skeleton"); mobInstance.AddComponent<Skeleton>(); break;
            case 3: mobInstance = new GameObject("Creeper"); mobInstance.AddComponent<Creeper>(); break;
            case 4: mobInstance = new GameObject("Cow"); mobInstance.AddComponent<Cow>(); break;
            case 5: mobInstance = new GameObject("Sheep"); mobInstance.AddComponent<Sheep>(); break;
            case 6: mobInstance = new GameObject("Pig"); mobInstance.AddComponent<Pig>(); break;
            case 7: mobInstance = new GameObject("Chicken"); mobInstance.AddComponent<Chicken>(); break;
            case 8: mobInstance = new GameObject("Horse"); mobInstance.AddComponent<Horse>(); break;
            case 9: mobInstance = new GameObject("Vampire"); mobInstance.AddComponent<Vampire>(); break;
            case 10: mobInstance = new GameObject("Wizard"); mobInstance.AddComponent<Wizard>(); break;
            case 11: mobInstance = new GameObject("Swordsman"); mobInstance.AddComponent<Swordsman>(); break;
            case 12: mobInstance = new GameObject("Enderman"); mobInstance.AddComponent<Enderman>(); break;
            case 13: mobInstance = new GameObject("Ghast"); mobInstance.AddComponent<Ghast>(); break;
            case 14: mobInstance = new GameObject("Bat"); mobInstance.AddComponent<Bat>(); break;
            case 15: mobInstance = new GameObject("Drone"); mobInstance.AddComponent<Drone>(); break;
            case 16: mobInstance = new GameObject("GiantWorm"); mobInstance.AddComponent<GiantWorm>(); break;
            case 17: mobInstance = new GameObject("Miner"); mobInstance.AddComponent<Miner>(); break;
            case 18: mobInstance = new GameObject("Demon"); mobInstance.AddComponent<Demon>(); break;
            case 19: mobInstance = new GameObject("Golem"); mobInstance.AddComponent<Golem>(); break;
            case 20: mobInstance = new GameObject("MiniBoss"); mobInstance.AddComponent<MiniBoss>(); break;
            case 21: mobInstance = new GameObject("Fairy"); mobInstance.AddComponent<Fairy>(); break;
            case 22: mobInstance = new GameObject("MiniDragon"); mobInstance.AddComponent<MiniDragon>(); break;
        }

        if (mobInstance != null)
        {
            mobInstance.transform.position = spawnPos;
            mobInstance.AddComponent<Rigidbody>();
            mobInstance.AddComponent<CapsuleCollider>();
            mobInstance.AddComponent<NavMeshAgent>();
            mobInstance.tag = "Mob";
            
            activeMobs.Add(mobInstance);
        }
    }
}

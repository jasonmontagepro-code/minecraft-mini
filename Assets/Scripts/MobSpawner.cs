using UnityEngine;
using UnityEngine.AI;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private int maxMobCount = 50;
    [SerializeField] private float spawnRadius = 50f;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private Transform playerTransform;
    
    private float lastSpawnTime = 0f;
    private int activeMobCount = 0;
    
    // Types de mobs à spawn
    private System.Type[] mobTypes = new System.Type[]
    {
        typeof(Zombie), typeof(Spider), typeof(Skeleton), typeof(Creeper),
        typeof(Cow), typeof(Sheep), typeof(Pig), typeof(Chicken), typeof(Horse),
        typeof(Vampire), typeof(Wizard), typeof(Swordsman),
        typeof(Enderman), typeof(Ghast), typeof(Bat), typeof(Drone),
        typeof(GiantWorm), typeof(Miner), typeof(Demon),
        typeof(Golem), typeof(MiniBoss), typeof(Fairy), typeof(MiniDragon)
    };

    private void Start()
    {
        if (playerTransform == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                playerTransform = playerObj.transform;
            else
                Debug.LogError("MobSpawner : Le Player n'a pas été trouvé ! Assurez-vous que le Player a le tag 'Player'");
        }
    }

    private void Update()
    {
        if (playerTransform == null) return;
        
        if (Time.time - lastSpawnTime > spawnCooldown && activeMobCount < maxMobCount)
        {
            SpawnRandomMob();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnRandomMob()
    {
        // Position de spawn aléatoire
        Vector3 spawnPos = playerTransform.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = 35f;

        // Type de mob aléatoire
        System.Type randomMobType = mobTypes[Random.Range(0, mobTypes.Length)];
        
        // Créer le GameObject
        GameObject mobInstance = new GameObject(randomMobType.Name);
        mobInstance.transform.position = spawnPos;
        
        // Ajouter les composants nécessaires
        Rigidbody rb = mobInstance.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        
        CapsuleCollider collider = mobInstance.AddComponent<CapsuleCollider>();
        collider.height = 2f;
        
        NavMeshAgent agent = mobInstance.AddComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.5f;
        
        // Ajouter le script du mob
        mobInstance.AddComponent(randomMobType);
        
        mobInstance.tag = "Mob";
        
        activeMobCount++;
        
        // Réduire le compteur quand le mob meurt
        StartCoroutine(TrackMobDeath(mobInstance));
    }

    private System.Collections.IEnumerator TrackMobDeath(GameObject mob)
    {
        while (mob != null)
        {
            yield return new WaitForSeconds(1f);
        }
        activeMobCount--;
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 spawnPosition = new Vector3(32, 30, 32);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

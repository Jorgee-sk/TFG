using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] _enemies;
    public GameObject playerPrefab;
    private GameObject _player;
    public EnemySpawner enemySpawner;
    public GameObject exitMenu;


    void Awake()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_player == null)
        {
            Debug.Log("Creating player instance");
            _player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
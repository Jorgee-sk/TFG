using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] _enemies;
    private GameObject _player;
    public EnemySpawner enemySpawner;


    void Start()
    {
        _enemies ??= GameObject.FindGameObjectsWithTag("Enemy");
        _player ??= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            _enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in _enemies)
            {
                Destroy(enemy);
            }

            enemySpawner.enabled = false;
        }
    }
}
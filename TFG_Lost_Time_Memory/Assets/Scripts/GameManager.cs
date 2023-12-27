using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] _enemies;
    private GameObject _player;


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
            foreach (var enemy in _enemies)
            {
                Destroy(enemy);
            }
        }
    }
}
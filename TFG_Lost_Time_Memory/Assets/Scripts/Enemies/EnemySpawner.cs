using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject father;
    public GameObject enemyPrefab;
    private List<Transform> _childTransforms;
    private GameObject[] _gameObjects;
    private float _deathTimer = 0f; 
    private float _spawnDelay = 5f;
    private int _maxHealth = 10;

    void Awake()
    {
        father = gameObject;
        _childTransforms = GetAllChildrenPositions(father.transform);
        InstanceFirstEnemies();
        _gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
    }

    List<Transform> GetAllChildrenPositions(Transform t)
    {
        List<Transform> transforms = new List<Transform>();

        Transform[] componentsInChildren = t.GetComponentsInChildren<Transform>();

        for (int i = 1; i < componentsInChildren.Length; i++)
        {
            transforms.Add(componentsInChildren[i]);
        }

        return transforms;
    }

    private void InstanceFirstEnemies()
    {
        foreach (Transform spawnerTransform in _childTransforms)
        {
            GameObject instantiate = Instantiate(enemyPrefab);
            instantiate.SetActive(false);
            instantiate.transform.position = spawnerTransform.position;
            instantiate.SetActive(true);
        }
    }
    
    void FixedUpdate (){

        foreach (GameObject enemy in _gameObjects)
        {
            if (enemy != null)
            {
                if (!enemy.activeSelf)
                {
                    _deathTimer += 1 * Time.deltaTime; //start death timer.
                }

                if (!enemy.activeSelf && _deathTimer >= _spawnDelay)
                {
                    Spawn(enemy);
                    _deathTimer = 0;
                }
            }
        }
        
    }

    private void Spawn(GameObject enemy)
    {
        enemy.SetActive(true);
        enemy.transform.position = Vector3.zero;
        _maxHealth += 2;
        enemy.GetComponent<EnemyController>().Health = _maxHealth;
    }
}
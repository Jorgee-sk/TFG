using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject father;
    public GameObject enemyPrefab;
    private List<Transform> _childTransforms;
    private List<GameObject> enemies;
    public float instantiationTimer;

    void Start()
    {
        father = gameObject;
        _childTransforms = GetAllChildren(father.transform);
    }

    List<Transform> GetAllChildren(Transform t)
    {
        List<Transform> transforms = new List<Transform>();

        Transform[] componentsInChildren = t.GetComponentsInChildren<Transform>();

        for (int i = 1; i < componentsInChildren.Length; i++)
        {
            transforms.Add(componentsInChildren[i]);
        }

        return transforms;
    }

    private void FixedUpdate()
    {
        instantiationTimer -= Time.deltaTime;
        if (instantiationTimer <= 0)
        {
            foreach (Transform spawnerTransform in _childTransforms)
            {
                GameObject instantiate = Instantiate(enemyPrefab);
                instantiate.SetActive(false);
                instantiate.transform.position = spawnerTransform.position;
                instantiate.SetActive(true);
                instantiationTimer = 20f;
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class BgPoolController : MonoBehaviour
{
    private List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int poolAmount;
    public bool defaultStatus;
    
    void Awake()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject instantiate = Instantiate(objectToPool);

            instantiate.SetActive(defaultStatus);

            pooledObjects.Add(instantiate);
        }
    }

    public GameObject GetFirstPooledObject()
    {
        return pooledObjects[0];
    }

    public GameObject GetElementOfPoolByIndex(int i)
    {
        return pooledObjects[i];
    }

    public List<GameObject> GetPooledObjects()
    {
        return pooledObjects;
    }
    
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolAmount; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
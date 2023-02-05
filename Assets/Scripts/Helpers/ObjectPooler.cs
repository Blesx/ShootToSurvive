using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToAdd;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
    }

    // Update is called once per frame
    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects) {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        IncreaseObjectPool();

        return GetPooledObject();
    }

    public void IncreaseObjectPool() {
        GameObject obj;
        
        for (int i = 0; i < amountToAdd; i++) {
            obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnInfo
{
    public GameObject prefab;
    public int amount;
}

public class Spawner : MonoBehaviour
{
    
    public SpawnInfo[] spawnInfos;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in spawnInfos)
        {
            for (int i = 0; i < item.amount; i++)
            {
                var bird = Instantiate(item.prefab);
                bird.transform.parent = gameObject.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public ObjectPool objectPool;
    public Transform[] position;

    float timer = 1.5f;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            InstantieBomb();
             timer = 1.5f;
        }
    }

    void InstantieBomb()
    {        
        GameObject obj = objectPool.GetObjectFromPool();

        Transform newPosition = position[Random.Range(0, position.Length)];
        obj.transform.position = newPosition.position;
    }
}

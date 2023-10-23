using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    float timer;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            timer = 0;
            GameManager.instance.poolManager.Get().transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        }
    }
}

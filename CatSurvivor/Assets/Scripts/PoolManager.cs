using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    ObjectPool<GameObject> pool;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(Create, OnGet, OnRelease, OnDestroy_, true, 10, 30);
    }

    private GameObject Create()
    {
        Debug.Log(1);
        var enemy = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
        enemy.GetComponent<Enemy>().SetPool(pool);
        return enemy;
    }

    private void OnGet(GameObject enemy)
    {
        enemy.gameObject.SetActive(true);
    }

    private void OnRelease(GameObject enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestroy_(GameObject enemy)
    {
        Destroy(enemy.gameObject);
    }

    public GameObject Get()
    {
        return pool.Get();
    }

    public void OnClick()
    {
        Get();
    }
}
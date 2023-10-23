using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    private bool isLive = true;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private ObjectPool<GameObject> objectPool;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        //Invoke("ReturnToPool", 5.0f);
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 direction = target.position - rigid.position;
        Vector2 nextVector = direction.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVector);
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }

    public void SetPool(ObjectPool<GameObject> pool)
    {
        this.objectPool = pool;
    }

    private void ReturnToPool()
    {
        objectPool.Release(gameObject);
    }
}

using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour {

    public float speed = 10;

    //public float lifeTime = 5;

    public int power = 1;
    private Vector2 max;
    private float lifeTime;
    // Use this for initialization
    void Start () {
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        lifeTime = (max.x * 2.0f) * 2.0f / speed;
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        //Destroy(gameObject, lifeTime);
        StartCoroutine(DelayMethod(lifeTime, () =>
        {
            ObjectPool.instance.ReleaseGameObject(gameObject);
            
        }));

    }
    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="waitTime">遅延時間[ミリ秒]</param>
    /// <param name="action">実行したい処理</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        ObjectPool.instance.ReleaseGameObject(gameObject);
    }

    
    void OnBecameVisible()
    {
        //GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        
    }
    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        StartCoroutine(DelayMethod(lifeTime, () =>
        {
            ObjectPool.instance.ReleaseGameObject(gameObject);

        }));

    }



}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

    public float speed;

    public float shotDelay;

    public GameObject bullet;

    public GameObject explosion;

    private Animator animator;

    public bool canShot;
	// Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Shoot());

    }

	IEnumerator Shoot (){
        while (canShot)
        {

            // shotDelay秒待つ
            yield return new WaitForSeconds(shotDelay);

            // 子要素を全て取得する
            foreach (Transform child in transform)
            {

                //Debug.Log(child.transform.position);
                long start = System.DateTime.Now.Ticks;
                // ShotPositionの位置/角度で弾を撃つ
                ObjectPool.instance.GetGameObject(bullet, child.transform.position, child.transform.rotation);

                // 処理時間でInstantiateとObjectPoolを比較してみる
                //Debug.Log(System.DateTime.Now.Ticks - start);
            }
        }

    }
	
   
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    
    public Animator GetAnimator()
    {
        return animator;
    }

}

using UnityEngine;
using System.Collections;

public class DestroyAreaBullet : MonoBehaviour {

    void Start()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 size = max * 3;

        GetComponent<BoxCollider2D>().size = size;
    }


    void OnTriggerExit2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName != ("Bullet(Player)") && (layerName != ("Bullet(Enemy)")))
        {

            Destroy(c.gameObject);
        }
    }
}

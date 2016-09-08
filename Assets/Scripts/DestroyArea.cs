using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

    void Start()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 size = max * 2;

        GetComponent<BoxCollider2D>().size = size;
    }


    void OnTriggerExit2D(Collider2D c)
    {

        Destroy(c.gameObject);
    }
}

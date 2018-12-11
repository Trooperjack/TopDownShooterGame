using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Collider2D bulletCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyScript = collision.collider.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.damaged();
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        LayerMask groundLayerMask = LayerMask.GetMask("Wall");
        bool touchingWall = bulletCollider.IsTouchingLayers(groundLayerMask);

        if (touchingWall == true)
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public Collider2D bulletCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerScript = collision.collider.GetComponent<Player>();

        if (playerScript != null)
        {
            playerScript.damaged();
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

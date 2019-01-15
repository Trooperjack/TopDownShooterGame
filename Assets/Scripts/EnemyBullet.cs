using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public Collider2D bulletCollider;


    private void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerScript = collision.collider.GetComponent<Player>();
        Bullet bulletScript = collision.collider.GetComponent<Bullet>();

        if (playerScript != null)
        {
            playerScript.damaged();
            Destroy(gameObject);
        }


        if (bulletScript != null)
        {
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

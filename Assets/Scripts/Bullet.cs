using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemyScript = collision.collider.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.damaged();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public Sprite[] bulletTextures;
    private Sprite currentTexture;
    public float loopDelay = 0.2f;
    private int counter;

    public Rect r_sprite;

    public Collider2D bulletCollider;
    public Animator bulletAnimator;
    public SpriteRenderer bulletSprite;

    private void Start()
    {
        counter = 0;
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartCoroutine("SwitchSprite");
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
        bulletSprite.sprite = currentTexture;

        if (touchingWall == true)
        {
            Destroy(gameObject);
        }
    }




    private IEnumerator SwitchSprite()
    {
        currentTexture = bulletTextures[counter];

        if (counter < bulletTextures.Length)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }

        yield return new WaitForSeconds(loopDelay);
        StartCoroutine("SwitchSprite");
    }


}

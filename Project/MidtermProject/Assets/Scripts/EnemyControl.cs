using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Rigidbody2D charBody;
    private SpriteRenderer charSprite;
    public GameObject enemy;
    private GameObject charHealth;
    public float speed = 3f;
    private int face = 1;

    void Start()
    {
        charBody = GetComponent<Rigidbody2D>();
        charSprite = GetComponent<SpriteRenderer>();
        charHealth = GameObject.Find("EnemyHealthBar");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charHealth.GetComponent<CharacterHealthControl>().getHp() <= 0)
        {
            Destroy(enemy);
        }
        if (transform.position.x <= 57.4f)
        {
            face = 1;
            charSprite.flipX = false;
        }
        else if(transform.position.x >= 62.72f)
        {
            face = -1;
            charSprite.flipX = true;
        }
        charBody.velocity = new Vector2(speed * face, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            if(collision.gameObject.transform.position.x <= transform.position.x)
            {
                charSprite.flipX = true;
            }
            else if(collision.gameObject.transform.position.x >= transform.position.x)
            {
                charSprite.flipX = false;
            }
            GetComponent<Animator>().SetBool("Attack", true);
        }
    }
}

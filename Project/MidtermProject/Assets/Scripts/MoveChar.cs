using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    private Vector2 newPos;
    
    public float speed;
    public float jumpForce;
    public float runningJumpForce;
    private Rigidbody2D charBody;
    private SpriteRenderer charSprite;
    private GameObject charHealth;
    private GameObject score;
    private int face = 1;
    private bool isRunning;
    private bool isAirBound = false;
    private bool isDead = false;
    private bool isGrounded = true;
    private bool win = false;

    void Start()
    {
        newPos = transform.position;
        charBody = GetComponent<Rigidbody2D>();
        charSprite = GetComponent<SpriteRenderer>();
        charHealth = GameObject.Find("HealthBar");
        score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (charHealth.GetComponent<CharacterHealthControl>().getHp() <= 0)
        {
            isDead = true;
        }

        if ((Input.GetKey(KeyCode.LeftArrow)) && (!isAirBound) && isGrounded && !win && !isDead)
        {
            //charBody.AddForce(new Vector2(-speed, 0));
            isRunning = true;
            GetComponent<Animator>().SetBool("Run", isRunning);
            face = -1;
            charBody.velocity = new Vector2(speed * face, 0);
            charSprite.flipX = true; // face to left because at the beginning, it faces to right
        }
        if ((Input.GetKey(KeyCode.RightArrow)) && (!isAirBound) && isGrounded && !win && !isDead)
        {
            //charBody.AddForce(new Vector2(+speed, 0));
            isRunning = true;
            GetComponent<Animator>().SetBool("Run", isRunning);
            face = 1;
            charBody.velocity = new Vector2(face * speed, 0);
            charSprite.flipX = false; // face to right

        }
        if (Input.GetKeyDown(KeyCode.Space) && (!isAirBound) && isGrounded && !win && !isDead)
        {
            if (isRunning)
            {
                //charBody.AddForce(new Vector2(face * speed * 5, runningJumpForce));
                charBody.AddForce(Vector2.up * runningJumpForce, ForceMode2D.Impulse);
            }
            else
            {
                //charBody.AddForce(new Vector2(0, runningJumpForce));
                charBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            isAirBound = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isRunning = false;
            GetComponent<Animator>().SetBool("Run", isRunning);
            if (!isAirBound && isGrounded)
            {
                charBody.velocity = new Vector2(0, 0);
            }

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRunning = false;
            GetComponent<Animator>().SetBool("Run", isRunning);
            if (!isAirBound && isGrounded)
            {
                charBody.velocity = new Vector2(0, 0);
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Animator>().SetTrigger("Attack");
            transform.GetChild(1).gameObject.GetComponent<SwordCollision>().setAttack();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string colliderName = collision.gameObject.name;
        if (colliderName.Contains("Dirt") ||
            colliderName.Contains("Grass") ||
            colliderName.Contains("GrassCliff") ||
            colliderName.Contains("GrassJoinHill") ||
            colliderName.Contains("GrassHill") ||
            colliderName.Contains("ashlandrock") ||
            colliderName.Contains("fotfor_lush") ||
            colliderName.Contains("fotfor_barren") ||
            colliderName.Contains("Enemy")
            )
        {
            isAirBound = false;
            isGrounded = true;
        }
        else if (colliderName.Contains("spikes")){

            float damage = 0;

            if (colliderName.Contains("spikes_2"))
            {
                damage = 20;
            }
            else if (colliderName.Contains("spikes_5") || colliderName.Contains("spikes_4"))
            {
                damage = 15;
            }
            else if(colliderName.Contains("spikes_8") || colliderName.Contains("spikes_9"))
            {
                damage = 20;
            }
            else if(colliderName.Contains("spikes_7"))
            {
                damage = 25;
            }
            else if (colliderName.Contains("spikes_6"))
            {
                damage = 20;
            }
            else if (colliderName.Contains("spikes_10"))
            {
                damage = 30;
            }
            else if (colliderName.Contains("spikes_12"))
            {
                damage = 30;
            }
            charHealth.gameObject.GetComponent<CharacterHealthControl>().takeDamage(damage);

            if (collision.gameObject.transform.position.y <= transform.position.y)
            {
                isAirBound = false;
                isGrounded = true;
            }
        }
        else if (colliderName.Contains("Mace"))
        {
            charHealth.gameObject.GetComponent<CharacterHealthControl>().takeDamage(60);
        }
        else if (colliderName.Contains("water"))
        {
            isDead = true;
        }
    }

    private void LateUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colliderName = collision.gameObject.name;
        if (colliderName.Contains("Coin"))
        {
            score.gameObject.GetComponent<ScoreControl>().increaseScore(100);
            Destroy(collision.gameObject);
        }
        else if (colliderName.Contains("health"))
        {
            charHealth.gameObject.GetComponent<CharacterHealthControl>().gainHealth(40);
            Destroy(collision.gameObject);
        }
        else if (colliderName.Contains("GoalFlag"))
        {
            win = true;
        }
    }

    public bool checkIsDead()
    {
        return isDead;
    }

    public void setIsDead()
    {
        this.isDead = true;
    }
    /*void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        charBody.AddForce(movement * speed);
    }*/
}

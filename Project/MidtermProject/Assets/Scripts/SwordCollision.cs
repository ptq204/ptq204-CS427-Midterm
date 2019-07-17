using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    // Start is called before the first frame update
    bool attack = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && (collision.gameObject.name.Contains("Enemy") || collision.gameObject.name.Contains("player")) && attack){
            GameObject charHealth = collision.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
            charHealth.GetComponent<CharacterHealthControl>().takeDamage(20);
        }
        attack = false;
    }

    public void setAttack()
    {
        attack = true;
    }
}

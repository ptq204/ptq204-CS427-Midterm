using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthControl : MonoBehaviour
{
    private float hp;
    private float startHp = 100f;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHp()
    {
        return this.hp;
    }

    public void setHp(float newHp)
    {
        this.hp = newHp;
    }

    public void takeDamage(float amount)
    {
        hp -= amount;

        healthBar.fillAmount = hp / startHp;

        if(this.hp <= 0)
        {
            Debug.Log("You died");
        }
    }

    public void gainHealth(float amount)
    {
        hp += amount;

        if(hp >= startHp)
        {
            hp = startHp;
        }

        healthBar.fillAmount = hp / startHp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    // Start is called before the first frame update

    private int gold = 0;
    public Text score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore(int amount)
    {
        gold += amount;
        score.text = "Score: " + gold.ToString();
    }

    public int getScore()
    {
        return this.gold;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDetection : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject scoreBoard;
    public Text score;
    public Text finalScore;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player").GetComponent<MoveChar>().checkIsDead())
        {
            scoreBoard.SetActive(true);
            finalScore.text = score.text;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            scoreBoard.SetActive(true);
            finalScore.text = score.text;
        }
    }
}

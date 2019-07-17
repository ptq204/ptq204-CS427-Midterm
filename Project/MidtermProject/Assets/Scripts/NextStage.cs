using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextStage()
    {
        int currentId = SceneManager.GetActiveScene().buildIndex;
        if(currentId + 1 == SceneManager.sceneCount)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            SceneManager.LoadScene(currentId + 1);
        }
    }
}

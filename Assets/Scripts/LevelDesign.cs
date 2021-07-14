using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDesign : MonoBehaviour
{
    
    private int myScore;

    private int Life;
    private Text scores;
    private Text lifes;

    // Start is called before the first frame update
    void Start()
    {
        scores = GameObject.Find("score").GetComponent<Text>();
        lifes = GameObject.Find("Life").GetComponent<Text>();

        //myScore.text;
    }

    // Update is called once per frame
    void Update()
    {
        myScore = GameObject.Find("NeogulMan").GetComponent<PlayerMovement>().score;
        Life = GameObject.Find("NeogulMan").GetComponent<PlayerMovement>().Life;
        scores.text = "score! : " + myScore;
        lifes.text = "life! : " + Life;

        Debug.Log(myScore);
        if (Life == 0)
        {
            GameObject.Find("gameover").GetComponent<Text>().text = "GAME OVER";
        }
    }
}

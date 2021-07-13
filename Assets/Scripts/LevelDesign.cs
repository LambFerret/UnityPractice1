using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDesign : MonoBehaviour
{
    
    private int myScore;
    private Text scores;
    // Start is called before the first frame update
    void Start()
    {
        myScore = GameObject.Find("NeogulMan").GetComponent<PlayerMovement>().score;
        scores = GameObject.Find("score").GetComponent<Text>();
        //myScore.text;
    }

    // Update is called once per frame
    void Update()
    {
        scores.text = "score! : " + myScore;
    }
}

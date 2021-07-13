using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItems : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject obj;
    public int ScorePerOne;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            Score += ScorePerOne;
            Debug.Log(Score);
        }
        Destroy(obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

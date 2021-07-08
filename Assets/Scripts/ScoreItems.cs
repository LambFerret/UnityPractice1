using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItems : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject obj;
    public int ScorePerOne;
    public int InitalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (obj.tag =="Player")
        {
            InitalScore += ScorePerOne;
            Debug.Log(InitalScore);
            print("1");
            Debug.Log('1');
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

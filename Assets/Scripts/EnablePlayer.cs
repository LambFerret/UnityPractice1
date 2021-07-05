using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
    public int PlayerSpeed = 3;
    public int PlayerShortJump = 1;
    public int PlayerLongJump = 3;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("NeogulMan");
        short life = 3;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    
}

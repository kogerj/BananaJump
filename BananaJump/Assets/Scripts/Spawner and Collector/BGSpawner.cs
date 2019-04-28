using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float heigest;
    private float highest_Y_Pos;


    void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("BG");
        
    }

    private void Start()
    {
        heigest = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        highest_Y_Pos = bgs[0].transform.position.y;

        for (int i = 1; i < bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > highest_Y_Pos)
                highest_Y_Pos = bgs[i].transform.position.y;

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Vector3 spawnPosition;
    public Transform playerTransform;

    private int hitpoint = 3;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y < -10)
        {
            playerTransform.position = spawnPosition;
        }

       
    }
}

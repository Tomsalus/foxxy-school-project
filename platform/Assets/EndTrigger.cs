using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public Animator animator;

    public GameMan gameManager;
    private int coinTotal;

    void OnTriggerEnter2D()
    {

        GameObject[] coinsArray = GameObject.FindGameObjectsWithTag("Coin");
        coinTotal = coinsArray.Length;
        GameObject.Find("Player").SendMessage("Finish");




        if (coinTotal == 0)
        {
            gameManager.CompleteLevel();
            animator.SetBool("isOpen", true);
        }
       
    }

}

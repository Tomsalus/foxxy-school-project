using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour

{
    public Vector3 spawnPosition;
    public Transform spawnpoint;
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    bool isOnGround = true;
    public Text pocettext;
    private int pocet;

    
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        pocet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            isOnGround = false;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }



    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("IsJumping", false);
        isOnGround = true;

       
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("neco");
        Debug.Log(collider.tag);

        if (collider.tag == "Enemy")
        {
            Respawn();
        }

        if (collider.CompareTag("Coin"))
            
        {
            Destroy(collider.gameObject);
            pocet = pocet+1;
            pocettext.text = "Coins: "+pocet;
        }
    }
 




    

    public void Respawn()
    {
        this.transform.position = spawnpoint.position;
    }









}

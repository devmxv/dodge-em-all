using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    public bool isGrounded = false;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    //---Player's Collider ref
    CapsuleCollider2D myBodyCollider;



    // Start is called before the first frame update
    void Start()
    {
        //---ref to RigidBody2D player
        myRigidBody = GetComponent<Rigidbody2D>();
        //---ref to Animator
        myAnimator = GetComponent<Animator>();
        //---ref to player's capsule collider
        myBodyCollider = GetComponent<CapsuleCollider2D>();
           
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FlipSprite();
        //Die();
    }

    private void Run()
    {
        //---uses for vector3 movement, not Vector2
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * moveSpeed;

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, myRigidBody.velocity.y);

        myRigidBody.velocity = movement;

        bool playerHasHoriztonalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHoriztonalSpeed);
    }

    private void Jump()
    {
        //---checks if the button for jump is pressed and it is grounded on the platform
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        //---if player is moving horizontallly
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    //---Destroy the player object when colliding with enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            //print("Is touching Enemy");
            Die();
        }


    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            //---call the load method from level when you die
            FindObjectOfType<Level>().showGameOver();
            Destroy(gameObject);
        }
    }


    //---Checks if the player is in a moving platform
    //---so it can move with the platform and it does not fall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //---I think it gets the name from the hierarchy instead of tags or layers
        if(collision.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    //---Checks if the player exits the moving platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Moving Platform"))
        {
            this.transform.parent = null;
        }
        
    }
}

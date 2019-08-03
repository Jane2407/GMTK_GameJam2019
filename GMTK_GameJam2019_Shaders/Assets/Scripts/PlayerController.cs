using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]  public bool drawDebugRaycasts = true;

    Rigidbody2D rb;

    [Header("Movement Properties")]
    [SerializeField] private int maxVel = 5;                     //Player x max velocity
    [SerializeField] private int minVel = -5;                    //Player x min velocity
    [SerializeField] private int speed = 10;                    //Player speed

    [Header("Jump Properties")]
    [SerializeField] public int jumpForce = 9;                   //Force of jump
    [SerializeField] public int defGravity;                      //Gravity default
    [SerializeField] public int gravity;                         //Gravity current

    [Header("Status Flags")]
    [SerializeField] public bool isOnGround;                     //Is the player on the ground?
    [SerializeField] public bool isJumping;                      //Is player jumping?
    [SerializeField] bool isFacingRight = true;				    //Direction player is facing
    [SerializeField] public bool isHaging;                       //Is player haging on wall?

    [Header("Environment Check Properties")]
    public float footOffsetX = .03f;            //X Offset of feet raycast
    public float footOffsetY = -.67f;           //Y Offset of feet raycast
    public float groundDistance = -.2f;         //Distance player is considered to be on the ground
    public LayerMask groundLayer;               //Layer of the ground
    public float eyeHeight = -.1f;              //Height of wall checks
    public float grabDistance = .4f;            //The reach distance for wall grabs

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PhysicsCheck();

        GroundMovement();
        MidAirMovement();

        //Limit x velocity
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, minVel, maxVel), rb.velocity.y);

        if (rb.velocity.x > 0 && !isFacingRight)
            FlipCharacter();
        else if (rb.velocity.x < 0 && isFacingRight)
            FlipCharacter();
    }

    void PhysicsCheck()
    {
        RaycastHit2D groundCheck = Raycast(new Vector2(footOffsetX, footOffsetY), Vector2.down, groundDistance);


        if (groundCheck)
        {
            if (groundCheck.collider.tag == "Floor")
            {
                groundCheck.collider.gameObject.GetComponent<TriangleController>().SetActive();
            }
            else if(groundCheck.collider.tag == "Death")
            {
                Death();
            }

            isOnGround = true;
            isJumping = false;
        }
        else
        {
            isOnGround = false;
        }

        Vector2 grabDir = new Vector2(1f, 0f);

        //Cast rays to look for a wall grab
        RaycastHit2D rightWallCheck = Raycast(new Vector2(footOffsetX, eyeHeight), grabDir, grabDistance);
        RaycastHit2D leftWallCheck = Raycast(new Vector2(footOffsetX, eyeHeight), -grabDir, grabDistance);

        if (rightWallCheck || leftWallCheck)
            isHaging = true;
        else
            isHaging = false;

        if (rightWallCheck)
        {
            if (rightWallCheck.collider.tag == "Floor")
            {
                rightWallCheck.collider.gameObject.GetComponent<TriangleController>().SetActive();
            }
        }
        else if (leftWallCheck)
        {
            if (leftWallCheck.collider.tag == "Floor")
            {
                leftWallCheck.collider.gameObject.GetComponent<TriangleController>().SetActive();
            }
        }
    }

    void GroundMovement()
    {
        //Chacking is player able to move on ground
        if (isHaging && !isOnGround)
            return;
        if (Input.GetAxis("Horizontal") != 0/*&& isJumping*/)
        {
            //Add force for horizontal movement
            rb.AddForce(Vector2.right * Input.GetAxis("Horizontal") * speed, ForceMode2D.Impulse);
        }
    }

    void MidAirMovement()
    {
        if (Input.GetAxis("Vertical")>0)
        {
            if (isOnGround)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            } 
            //else if (!isOnGround && !isJumping)
            //{
            //    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                
            //}
        }
    }

    void FlipCharacter() // Flip character
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    {
        //Call the overloaded Raycast() method using the ground layermask and return the results
        return Raycast(offset, rayDirection, length, groundLayer);
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
    {
        //Record the player's position
        Vector2 pos = transform.position;

        //Send out the desired raycasr and record the result
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

        //Show raycast in scene
        if (drawDebugRaycasts)
        {
            //...determine the color based on if the raycast hit...
            Color color = hit ? Color.red : Color.green;
            //...and draw the ray in the scene view
            Debug.DrawRay(pos + offset, rayDirection * length, color);
        }
        //Return the results of the raycast
        return hit;
    }

    void Death()
    {
        GameObject go= GameObject.FindGameObjectWithTag("RecordsManager");
        go.GetComponent<RecordsManager>().EndRound();
    }

   
}

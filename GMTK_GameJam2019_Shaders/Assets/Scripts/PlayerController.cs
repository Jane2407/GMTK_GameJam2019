using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool drawDebugRaycasts = true;

    Rigidbody2D rb2d;

    [Header("Movement Properties")]
    public int maxVel;
    public int minVel;
    public int speed;

    [Header("Jump Properties")]
    public int jumpForce;
    //[SerializeField] public int defGravity;
    //[SerializeField] public int gravity;

    [Header("Status Flags")]
    public bool isOnGround;

    [Header("Environment Check Properties")]
    public Transform raycastLeft;
    public Transform raycastMiddle;
    public Transform raycastRight;
    public float groundDistance;
    public LayerMask groundLayer;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PhysicsCheck();

        Move();

        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, minVel, maxVel), rb2d.velocity.y);
    }

    void PhysicsCheck()
    {

        RaycastHit2D hitL = Physics2D.Raycast(raycastLeft.position, Vector2.down, groundDistance, groundLayer);

        RaycastHit2D hitM = Physics2D.Raycast(raycastMiddle.position, Vector2.down, groundDistance, groundLayer);

        RaycastHit2D hitR = Physics2D.Raycast(raycastRight.position, Vector2.down, groundDistance, groundLayer);

        if (drawDebugRaycasts)
        {
            Color colorL = hitL ? Color.red : Color.green;
            Debug.DrawRay(raycastLeft.position, Vector2.down * groundDistance, colorL);

            Color colorM = hitM ? Color.red : Color.green;
            Debug.DrawRay(raycastMiddle.position, Vector2.down * groundDistance, colorM);

            Color colorR = hitR ? Color.red : Color.green;
            Debug.DrawRay(raycastRight.position, Vector2.down * groundDistance, colorR);
        }

        if (hitL || hitM || hitR)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void Move()
    {
        rb2d.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * speed, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;
            }
        }

    }

    void Death()
    {
        GameObject.FindGameObjectWithTag("RecordsManager").GetComponent<RecordsManager>().EndRound();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            collision.collider.gameObject.GetComponent<TriangleController>().SetActive();
        }
        else if (collision.collider.tag == "Death")
        {
            collision.collider.gameObject.GetComponent<TriangleController>().SetActive();
            Death();
        }
    }

}

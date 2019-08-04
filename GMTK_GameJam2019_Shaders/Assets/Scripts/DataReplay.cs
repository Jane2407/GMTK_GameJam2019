﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReplay : MonoBehaviour
{
    //[SerializeField] public bool drawDebugRaycasts = true;

    //Rigidbody2D rb2d;

    public List<RecordFrame> record;            //List with all frame records from previous player's round
    int index;                                  //Index of current record frame       

    //[Header("Status Flags")]
    //[SerializeField] bool isFacingRight = true;	//Direction player is facing

    //[Header("Environment Check Properties")]
    //public float footOffsetX = .03f;            //X Offset of feet raycast
    //public float footOffsetY = -.67f;           //Y Offset of feet raycast
    //public float groundDistance = -.2f;         //Distance player is considered to be on the ground
    //public LayerMask groundLayer;               //Layer of the ground
    //public float eyeHeight = -.1f;              //Height of wall checks
    //public float grabDistance = .4f;            //The reach distance for wall grabs

    //private void Start()
    //{
    //    rb2d = GetComponent<Rigidbody2D>();
    //}

    private void FixedUpdate()
    {
        //PhysicsCheck();

        //Checking for any available record frames
        if (index > record.Count - 1)
        {
            //Destroy ghost
            GameObject.FindGameObjectWithTag("RecordsManager").GetComponent<RecordsManager>().playersCopies.Remove(gameObject);
            Destroy(gameObject);

        }
        else
        {
            //Setting ghost position and rotation from record
            transform.position = record[index].position;

            //Adding index for next frame
            index++;
        }
    }

    //void PhysicsCheck()
    //{
    //    RaycastHit2D groundCheck = Raycast(new Vector2(footOffsetX, footOffsetY), Vector2.down, groundDistance);

    //    if (groundCheck)
    //    {
    //        if (groundCheck.collider.tag == "Floor")
    //        {
    //            groundCheck.collider.gameObject.GetComponent<TriangleController>().SetActive();
    //        }
    //    }

    //    Vector2 grabDir = new Vector2(1f, 0f);

    //    //Cast rays to look for a wall grab
    //    RaycastHit2D rightWallCheck = Raycast(new Vector2(footOffsetX, eyeHeight), grabDir, grabDistance);
    //    RaycastHit2D leftWallCheck = Raycast(new Vector2(footOffsetX, eyeHeight), -grabDir, grabDistance);


    //    if (rightWallCheck)
    //    {
    //        if (rightWallCheck.collider.tag == "Floor")
    //        {
    //            rightWallCheck.collider.gameObject.GetComponent<TriangleController>().SetActive();
    //        }
    //    }
    //    else if (leftWallCheck)
    //    {
    //        if (leftWallCheck.collider.tag == "Floor")
    //        {
    //            leftWallCheck.collider.gameObject.GetComponent<TriangleController>().SetActive();
    //        }
    //    }
    //}


    //RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length)
    //{
    //    //Call the overloaded Raycast() method using the ground layermask and return the results
    //    return Raycast(offset, rayDirection, length, groundLayer);
    //}

    //RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask mask)
    //{
    //    //Record the player's position
    //    Vector2 pos = transform.position;

    //    //Send out the desired raycasr and record the result
    //    RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, mask);

    //    //Show raycast in scene
    //    if (drawDebugRaycasts)
    //    {
    //        //...determine the color based on if the raycast hit...
    //        Color color = hit ? Color.red : Color.green;
    //        //...and draw the ray in the scene view
    //        Debug.DrawRay(pos + offset, rayDirection * length, color);
    //    }
    //    //Return the results of the raycast
    //    return hit;
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            collision.collider.gameObject.GetComponent<TriangleController>().SetActive();
        }
        else if (collision.collider.tag == "Death")
        {
            collision.collider.gameObject.GetComponent<TriangleController>().SetActive();
        }
    }
}

using System.Collections;
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

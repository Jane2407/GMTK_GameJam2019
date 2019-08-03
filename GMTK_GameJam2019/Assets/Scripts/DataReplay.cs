using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReplay : MonoBehaviour
{
    Rigidbody2D rb2d;

    public List<RecordFrame> record;            //List with all frame records from previous player's round
    int index;                                  //Index of current record frame                         

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Checking for any available record frames
        if (index > record.Count - 1)
        {
            //Destroy ghost
            transform.parent.gameObject.GetComponent<RecordsManager>().playersCopies.Remove(gameObject);
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
}

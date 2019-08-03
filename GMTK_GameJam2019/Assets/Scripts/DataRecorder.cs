using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRecorder : MonoBehaviour
{
    public List<RecordFrame> record;
    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        record = new List<RecordFrame>();
    }

    //Recordng all values every frame
    private void FixedUpdate()
    {

        RecordFrame recordFrame = new RecordFrame();

        recordFrame.position = transform.position;
        recordFrame.velocity = rb2d.velocity;

        record.Add(recordFrame);
    }
}
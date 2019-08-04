using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRecorder : MonoBehaviour
{
    public List<RecordFrame> record;

    private void Start()
    {
        record = new List<RecordFrame>();
    }

    private void FixedUpdate()
    {
        RecordFrame recordFrame = new RecordFrame();

        recordFrame.position = transform.position;

        record.Add(recordFrame);
    }
}
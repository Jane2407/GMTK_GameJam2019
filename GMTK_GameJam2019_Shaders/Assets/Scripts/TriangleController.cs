using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    [SerializeField] Color32 color;
    [SerializeField] SpriteRenderer rend;

    [SerializeField] float time;
    [SerializeField] float deactivationTime;
    [SerializeField] bool isTicking;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isTicking)
        {
            if (time < deactivationTime)
            {
                time += Time.deltaTime;
            }
            else
            {
                SetInactive();
            }
        }
    }

    public void SetActive()
    {
        time = 0;
        isTicking = true;

        if (rend != null)
        {
            rend.enabled = true;
        }
        else
        {
            Debug.Log("Player was touching a triangle at start", this);
        }
        
    }

    void SetInactive()
    {
        time = 0;
        isTicking = false;
        rend.enabled = false;
    }

}

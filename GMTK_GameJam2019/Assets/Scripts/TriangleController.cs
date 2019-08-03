using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    [SerializeField] Color32 color;
    [SerializeField] SpriteRenderer rend;

    [SerializeField] float time;
    [SerializeField] float activeTime;
    [SerializeField] bool isActivated;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        time = activeTime;
    }

    private void Update()
    {
        if (isActivated)
        {
            if (time > 0)
            {
                time -= Time.deltaTime ;
            }
            else
            {
                time = activeTime;
                SetInactive();
            }
        }
    }

    public void SetActive()
    {
        isActivated = true;
        rend.enabled = true;
    }

    void SetInactive()
    {
        isActivated = false;
        rend.enabled = false;
    }

}

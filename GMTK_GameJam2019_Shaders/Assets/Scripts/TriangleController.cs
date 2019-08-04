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

    Animator anim; 

    private void Start()
    {
        anim = GetComponent<Animator>();
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
                anim.SetTrigger("Inactive");
            }
        }
    }

    public void SetActive()
    {
        anim.enabled = true;

        time = 0;
        isTicking = true;

        if (rend != null)
        {
            rend.enabled = true;
        }
    }

    void SetInactive()
    {
        time = 0;
        isTicking = false;

        if (gameObject.tag == "Floor")
        {
            rend.enabled = false;
            anim.enabled = false;
        }
    }

    public void Impulse()
    {
        SetActive();
        anim.SetTrigger("Inactive");
    }

}

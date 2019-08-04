using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    Collider2D col;
    GameManager gm;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gm.GotPoint();
        }
    }
}

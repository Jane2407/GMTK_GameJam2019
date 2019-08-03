using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] enum Mode { DEFAULT, ONETIME, GRAVITY, ROTATION};

    [SerializeField] Mode currentMode;

    [SerializeField] public GameObject level;
    [SerializeField] public Transform levelDefualt;
    [SerializeField] public PlayerController player;
    [SerializeField] public GameObject playerPosPrefab;



    private void Start()
    {
        currentMode = Mode.DEFAULT;
    }

    void ChangeMode(Mode newMode)
    {
        switch (newMode)
        {
            case Mode.DEFAULT:

                //Default gravity
                player.gravity = player.defGravity;

                //Default level
                level.transform.position = levelDefualt.transform.position;
                level.transform.rotation = levelDefualt.transform.rotation;

                //Default platforms
                foreach (GameObject child in level.transform)
                {
                    child.SetActive(true);
                    child.GetComponent<SpriteRenderer>().enabled = false;
                    //change bool in child
                }
                break;

            case Mode.ONETIME:
                break;

            case Mode.GRAVITY:

                //Set negative gravity
                player.gravity = -player.gravity;
                break;

            case Mode.ROTATION:

                

                break;
            default:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsManager : MonoBehaviour
{
    [Header("Records List")]
    [SerializeField] public List<List<RecordFrame>> replays;

    [Header("Player and ghosts")]
    public GameObject player;
    public List<GameObject> playersCopies;

    public int maxCopies;

    [Header("Players and ghost Prefabs")]
    public GameObject playerPrefab;
    public GameObject playersCopyPrefab;

    private void Start()
    {
        replays = new List<List<RecordFrame>>();
        playersCopies = new List<GameObject>();
        InstantiatePlayer();
    }

    //Instantiate player
    void InstantiatePlayer()
    {
        GameObject go = Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
        player = go;

        Camera.main.GetComponent<CameraFollow>().player = go.transform;
        Camera.main.GetComponent<CameraFollow>().isOldPlayer = false;
    }

    void InstantiateCopies()
    {
        foreach (List<RecordFrame> replay in replays)
        {
            GameObject go = Instantiate(playersCopyPrefab, transform);
            playersCopies.Add(go);
            go.GetComponent<DataReplay>().record = replay;
        }

        int temp = playersCopies.Count - 10;
        if (temp > 0)
        {
            for (int i = 0; i < temp; i++)
            {
                Destroy(playersCopies[temp - 1]);
            }
        }
    }

    public void EndRound()
    {
        FreezeAll();
        Invoke("RestartRound", 1f);
    }

    void DeleteAll()
    {
        foreach (GameObject _playersCopy in playersCopies)
        {
            Destroy(_playersCopy);
        }

        //Clearing ghosts list
        playersCopies.Clear();

        //Pushing records to Replay list
        replays.Add(player.GetComponent<DataRecorder>().record);
        Debug.Log(replays.Count);
        Destroy(player);
    }

    void RestartRound()
    {
        DeleteAll();
        InstantiatePlayer();
        InstantiateCopies();

        Debug.Log(replays.Count);
    }

    //Freezing all players and ghost when player died
    void FreezeAll()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


        for (int i = 0; i < playersCopies.Count; i++)
        {
            if (playersCopies[i] != null)
                playersCopies[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}

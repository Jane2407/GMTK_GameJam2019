using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsManager : MonoBehaviour
{
    [Header("Records List")]
    public List<List<RecordFrame>> replays;

    [Header("Player and ghosts")]
    public GameObject player;
    public List<GameObject> playersCopies;

    [Header("Players and ghost Prefabs")]
    public GameObject playerPrefab;
    public GameObject playersCopyPrefab;

    public Transform startPoint;

    public bool isRoundEnd;

    private void Start()
    {
        replays = new List<List<RecordFrame>>();
        playersCopies = new List<GameObject>();
        InstantiatePlayer();
    }

    //Instantiate player
    void InstantiatePlayer()
    {
        GameObject go = Instantiate(playerPrefab, transform.position, Quaternion.identity);

        player = go;
    }

    void InstantiateCopies()
    {
        foreach (List<RecordFrame> replay in replays)
        {
            GameObject go = Instantiate(playersCopyPrefab, transform);
            playersCopies.Add(go);
            go.GetComponent<DataReplay>().record = replay;
        }
    }

    public void EndRound()
    {
        if (!isRoundEnd)
        {
            FreezeAll();
            isRoundEnd = true;
            Invoke("RestartRound", 1f);
        }
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
        Destroy(player);
        player = null;

    }

    void RestartRound()
    {
        DeleteAll();
        InstantiatePlayer();
        InstantiateCopies();
        isRoundEnd = false;
    }

    //Freezing all players and ghost when player died
    void FreezeAll()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


        for (int j = 0; j < playersCopies.Count; j++)
        {
            if (playersCopies[j] != null)
                playersCopies[j].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}

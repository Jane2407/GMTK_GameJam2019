using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] public Texture2D colorMapFloor;
    [SerializeField] public Texture2D colorMapWallR;
    [SerializeField] public Texture2D colorMapWallL;
    [SerializeField] public Texture2D colorMapSpikes;

    [Header("Level prefabs")]
    [SerializeField] public GameObject floorPrefab;
    [SerializeField] public GameObject wallPrefab;
    [SerializeField] public GameObject spikesPrefab;

    [Header("Position Properties")]
    [SerializeField] public float multiplyerX;
    [SerializeField] public float multiplyerY;

    public void Start()
    {
        //Generate all floor platforms
        for (int i = 0; i < colorMapFloor.width; i++)
        {
            for (int j = 0; j < colorMapFloor.height; j++)
            {
                if (colorMapFloor.GetPixel(i, j).grayscale == 1f)
                {
                    Instantiate(floorPrefab, new Vector3(i * multiplyerX, j * multiplyerY, 0), Quaternion.identity);
                }
            }
        }

        ////Generate all spickes
        //for (int i = 0; i < colorMapSpikes.width; i++)
        //{
        //    for (int j = 0; j < colorMapSpikes.height; j++)
        //    {
        //        if (colorMapSpikes.GetPixel(i, j).grayscale == 1f)
        //        {
        //            Instantiate(spikesPrefab, new Vector3(i * multiplyerX, j * multiplyerY, 0), Quaternion.identity);
        //        }
        //    }
        //}

        ////Generate All R Walls
        //for (int i = 0; i < colorMapWallR.width; i++)
        //{
        //    for (int j = 0; j < colorMapWallR.height; j++)
        //    {
        //        if (colorMapWallR.GetPixel(i, j).grayscale == 1f)
        //        {
        //            Instantiate(wallPrefab, new Vector3(i * multiplyerX, j * multiplyerY, 0), Quaternion.identity);
        //        }
        //    }
        //}

        ////Generate all L walls
        //for (int i = 0; i < colorMapWallL.width; i++)
        //{
        //    for (int j = 0; j < colorMapWallL.height; j++)
        //    {
        //        if (colorMapWallL.GetPixel(i, j).grayscale == 1f)
        //        {
        //            Instantiate(wallPrefab, new Vector3(i * multiplyerX, j * multiplyerY, 0), Quaternion.identity);
        //        }
        //    }
        //}
    }
}

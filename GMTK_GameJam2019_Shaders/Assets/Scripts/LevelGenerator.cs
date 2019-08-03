using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromTexture : MonoBehaviour
{
    [SerializeField] public Texture2D colorMap;
    [SerializeField] public GameObject prefab;

    [SerializeField] public float multiplyerX;
    [SerializeField] public float multiplyerY;

    public void Start()
    {
        for (int i = 0; i < colorMap.width; i++)
        {
            for (int j = 0; j < colorMap.height; j++)
            {
                if (colorMap.GetPixel(i, j).grayscale < 0.5f)
                {
                    Instantiate(prefab, new Vector3(i * multiplyerX, j * multiplyerY, 0), Quaternion.identity);
                }
            }
        }
    }
}

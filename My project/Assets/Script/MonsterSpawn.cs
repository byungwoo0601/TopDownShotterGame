using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] monPrefab;
    public Camera cam;
    public float spawnTime = 5f;
    public float distanceFromPlayer = 5f;

    private Transform playerTransform;

    public int percentage = 0;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;

        InvokeRepeating("RespawnMonsters", 0f, spawnTime);
    }

    void RespawnMonsters()
    {
        if (cam != null && monPrefab != null && playerTransform != null)
        {
            float camHeight = 2f * cam.orthographicSize;
            float camWidth = camHeight * cam.aspect;

            Vector3 dir = new Vector3(
                Random.Range(-camWidth / 2f, camWidth / 2f),
                Random.Range(-camHeight / 2f, camHeight / 2f),
                0f
            );

            while (Vector3.Distance(playerTransform.position, dir) < distanceFromPlayer)
            {
                dir = new Vector3(
                    Random.Range(-camWidth / 2f, camWidth / 2f),
                    Random.Range(-camHeight / 2f, camHeight / 2f),
                    0f
                );
            }
            int N = Percentage();

            Instantiate(monPrefab[N], dir, Quaternion.identity);
        }
    }

    public int Percentage()
    {
        int num = 0;

        int n = Random.Range(0, 101);

        if(n >= percentage)
        {
            num = 0;
        }
        else
        {
            num = 1;
        }

        return num;
    }
}

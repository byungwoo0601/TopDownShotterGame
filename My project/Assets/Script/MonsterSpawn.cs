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

    public void ChangeMonster()
    {
        //1스테이지에 10마리 세모 10
        /*2 스테이지 10마리 세모 7 네모 3
         * 3스테이지 12마리 세모 5 네모 7
         * 
         * - 세모 22 네모 10
         * 
         * 4스테이지 10마리 네모 10
         * 5스테이지 9마리 보스 1 세모 5 네모 3
         * 
         * - 세모 27 네모 23 보스1
         */
        int curStage;
        int totalMonster;

        int triangleMonster;
        int squareMonster;

    }
}

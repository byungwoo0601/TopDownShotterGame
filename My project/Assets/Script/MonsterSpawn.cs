using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] monPrefab;
    public Camera cam;
    public float spawnTime = 5f;
    public float distanceFromPlayer = 5f;

    private Transform playerTransform;

    public int percentage = 0;
    GameObject mon;
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;

    }

    private void Update()
    {

        if (transform.childCount == 0)
        {
            if (UIManager.Instance.stage > 5)
            {
                SceneManager.LoadScene("End");
            }
            ChangeMonster();
            UIManager.Instance.CurStageInfo();
            UIManager.Instance.stage++;
        }

      

    }

    public void ChangeMonster()
    {
        //1스테이지에  세모 5
        /*2 스테이지  세모 4 네모 3
         * 3스테이지  세모 6 네모 7
         * 4스테이지  네모 10
         * 5스테이지  보스 1
         * 
         */
        int curStage = UIManager.Instance.stage;

        int triangleMonster = 0;
        int squareMonster = 0;
        bool bossMonster = false;
        int percent;


        switch (curStage)
        {
            case 1:
                triangleMonster = 5;
                squareMonster = 0;
                bossMonster = false;
                percent = 0;

                _MonsterSpawn(triangleMonster, squareMonster, bossMonster, percent);
                break;
            case 2:
                triangleMonster = 4;
                squareMonster = 3;
                bossMonster = false;

                percent = 30;
                _MonsterSpawn(triangleMonster, squareMonster, bossMonster, percent);

                break;
            case 3:
                triangleMonster = 6;
                squareMonster = 7;
                bossMonster = false;
                percent = 60;
                _MonsterSpawn(triangleMonster, squareMonster, bossMonster, percent);

                break;
            case 4:
                triangleMonster = 0;
                squareMonster = 10;
                bossMonster = false;
                percent = 100;
                _MonsterSpawn(triangleMonster, squareMonster, bossMonster, percent);

                break;
            case 5:
                triangleMonster = 0;
                squareMonster = 0;
                bossMonster = true;
                percent = 0;
                _MonsterSpawn(triangleMonster, squareMonster, bossMonster, percent);

                break;
        }
    }

    void _MonsterSpawn(int trinagle, int square, bool boss = false, int percent = 0)
    {
        int _boss = boss ? 1 : 0;

        int n = trinagle + square + _boss;


        if (cam != null && monPrefab != null && playerTransform != null)
        {
            float camHeight = 2f * cam.orthographicSize;
            float camWidth = camHeight * cam.aspect;

            for (int i = 0; i < n; i++)
            {

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

                int N = Percentage(percent, boss);
                mon = Instantiate(monPrefab[N], dir, Quaternion.identity);
                mon.transform.parent = transform;
            }
        }
    }


    public int Percentage(int percent, bool boss)
    {
        int num = 0;

        int n = Random.Range(0, 101);

        if (n >= percent)
        {
            num = 0;
        }
        else
        {
            num = 1;
        }

        if (boss)
        {
            num = 2;
        }
        return num;
    }
}

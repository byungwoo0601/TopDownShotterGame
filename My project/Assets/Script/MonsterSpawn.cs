using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monPrefab;
    public Camera cam;
    public float spawnTime = 5f;

    void Start()
    {
        // 주기적으로 몬스터 생성 함수를 호출
        InvokeRepeating("RespwanMonsters", 0f, spawnTime);
    }

    void RespwanMonsters()
    {
        if (cam != null && monPrefab != null)
        {
            // 카메라의 시야 영역을 가져옴
            float camHeight = 2f * cam.orthographicSize;
            float camWidth = camHeight * cam.aspect;

            // 랜덤한 위치 계산
            Vector3 dir = new Vector3(
                Random.Range(-camWidth / 2f, camWidth / 2f),
                Random.Range(-camHeight / 2f, camHeight / 2f),
                0f
            );

            // 몬스터를 랜덤한 위치에 생성
            Instantiate(monPrefab, dir, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traking : MonoBehaviour
{
    Transform player; // 플레이어의 Transform을 저장할 변수
    public float trakingSpeed = 5f; // 몬스터의 추적 속도

    public int hp;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // 몬스터를 플레이어 방향으로 이동시킴
        Tracking();
    }

    void Tracking()
    {
        if (player != null)
        {
            // 몬스터의 현재 위치에서 플레이어를 향하는 방향을 계산
            Vector3 dir = player.position - transform.position;
            dir.Normalize(); // 방향 벡터를 정규화하여 길이가 1이 되도록 함

            // 몬스터를 플레이어 방향으로 이동
            transform.Translate(dir* trakingSpeed * Time.deltaTime);
        }
    }
}

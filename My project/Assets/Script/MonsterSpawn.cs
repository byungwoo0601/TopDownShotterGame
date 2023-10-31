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
        // �ֱ������� ���� ���� �Լ��� ȣ��
        InvokeRepeating("RespwanMonsters", 0f, spawnTime);
    }

    void RespwanMonsters()
    {
        if (cam != null && monPrefab != null)
        {
            // ī�޶��� �þ� ������ ������
            float camHeight = 2f * cam.orthographicSize;
            float camWidth = camHeight * cam.aspect;

            // ������ ��ġ ���
            Vector3 dir = new Vector3(
                Random.Range(-camWidth / 2f, camWidth / 2f),
                Random.Range(-camHeight / 2f, camHeight / 2f),
                0f
            );

            // ���͸� ������ ��ġ�� ����
            Instantiate(monPrefab, dir, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traking : MonoBehaviour
{
    Transform player; // �÷��̾��� Transform�� ������ ����
    public float trakingSpeed = 5f; // ������ ���� �ӵ�

    public int hp;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // ���͸� �÷��̾� �������� �̵���Ŵ
        Tracking();
    }

    void Tracking()
    {
        if (player != null)
        {
            // ������ ���� ��ġ���� �÷��̾ ���ϴ� ������ ���
            Vector3 dir = player.position - transform.position;
            dir.Normalize(); // ���� ���͸� ����ȭ�Ͽ� ���̰� 1�� �ǵ��� ��

            // ���͸� �÷��̾� �������� �̵�
            transform.Translate(dir* trakingSpeed * Time.deltaTime);
        }
    }
}

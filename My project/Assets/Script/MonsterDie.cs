using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    public GameObject explosionEffectPrefab;


    private void Update()
    {
        if(GetComponent<Traking>().hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ���� ����Ʈ�� ����
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        // ���Ͱ� ������ �� ������� Ƣ���� ���� ȿ�� ����
        Rigidbody2D[] allrigid = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rid in allrigid)
        {
            Vector3 ramdonDir = new Vector3(Random.Range(-5f, 5f), Random.Range(2f, 10f), Random.Range(-5f, 5f));
            rid.AddForce(ramdonDir, ForceMode2D.Impulse);
        }
    }
}

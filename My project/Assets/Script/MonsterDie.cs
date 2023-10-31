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
        // 폭발 이펙트를 생성
        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

        // 몬스터가 폭발할 때 사방으로 튀도록 폭발 효과 적용
        Rigidbody2D[] allrigid = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rid in allrigid)
        {
            Vector3 ramdonDir = new Vector3(Random.Range(-5f, 5f), Random.Range(2f, 10f), Random.Range(-5f, 5f));
            rid.AddForce(ramdonDir, ForceMode2D.Impulse);
        }
    }
}

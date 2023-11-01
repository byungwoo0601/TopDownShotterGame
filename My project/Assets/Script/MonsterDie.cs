using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    public GameObject debrisPrefab; // 파편 프리팹 설정
    public int debrisCount = 10; // 생성할 파편 개수
    public float explosionForce = 0.3f; // 폭발력


    private void OnDestroy()
    {
        Explode();
    }

    void Explode()
    {
        if(transform.tag == "Monster1")
        {
            UIManager.Instance.uiInfo.triangleCount++;
        }
        else if(transform.tag == "Monster2")
        {
            UIManager.Instance.uiInfo.squareCount++;
        }


        for (int i = 0; i < debrisCount; i++)
        {
            GameObject debris = Instantiate(debrisPrefab, transform.position, Quaternion.identity);

            Rigidbody2D debrisRb = debris.GetComponent<Rigidbody2D>();
            Vector2 explosionDirection = Random.insideUnitCircle.normalized;
            debrisRb.AddForce(explosionDirection * explosionForce, ForceMode2D.Impulse);

            Destroy(debris, 1f);
        }

        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }
}

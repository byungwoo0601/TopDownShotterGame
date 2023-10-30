using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bulletPos;
    public GameObject preFabBullet;
    public float bulletSpeed = 10f;  // 원하는 일정한 총알 속도
    public float attackSpeed = 0.5f;  // 발사 간격

    private float time;

    void Update()
    {
        time += Time.deltaTime;

        if (time > attackSpeed)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            time = 0;

            // 마우스의 현재 위치를 기준으로 발사 방향을 계산
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (mousePosition - bulletPos.transform.position).normalized;

            // 총알을 생성하고 초기 위치와 방향을 설정
            GameObject bullet = Instantiate(preFabBullet, bulletPos.transform.position, Quaternion.FromToRotation(Vector3.up, shootDirection));

            // 총알에 일정한 속도를 적용하여 발사 (벡터 정규화)
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shootDirection.normalized * bulletSpeed;

            Destroy(bullet, 2f);
        }
    }
}
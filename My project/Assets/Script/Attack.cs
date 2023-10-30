using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bulletPos;
    public GameObject preFabBullet;
    public float bulletSpeed = 10f;  // ���ϴ� ������ �Ѿ� �ӵ�
    public float attackSpeed = 0.5f;  // �߻� ����

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

            // ���콺�� ���� ��ġ�� �������� �߻� ������ ���
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (mousePosition - bulletPos.transform.position).normalized;

            // �Ѿ��� �����ϰ� �ʱ� ��ġ�� ������ ����
            GameObject bullet = Instantiate(preFabBullet, bulletPos.transform.position, Quaternion.FromToRotation(Vector3.up, shootDirection));

            // �Ѿ˿� ������ �ӵ��� �����Ͽ� �߻� (���� ����ȭ)
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shootDirection.normalized * bulletSpeed;

            Destroy(bullet, 2f);
        }
    }
}
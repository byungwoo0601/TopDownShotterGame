using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bulletPos;
    public GameObject preFabBullet;
    public float bulletSpeed;
    public float attackSpeed;

    public Transform player;

    private float time;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

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
        if (Input.GetMouseButton(0) && transform.tag == "Player")
        {
            time = 0;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (mousePosition - bulletPos.transform.position).normalized;

            GameObject bullet = Instantiate(preFabBullet, bulletPos.transform.position, Quaternion.FromToRotation(Vector3.up, shootDirection));

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shootDirection.normalized * bulletSpeed;

            Destroy(bullet, 2f);
        }

        if(transform.tag == "Monster")
        {
            time = 0;

            Vector3 dir = (player.position - bulletPos.transform.position).normalized;
            GameObject bullet = Instantiate(preFabBullet, bulletPos.transform.position, Quaternion.FromToRotation(Vector3.up, dir));

            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

            Destroy(bullet, 4f);
        }
    }
    
}
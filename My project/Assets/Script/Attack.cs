using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bulletPos;
    public GameObject preFabBullet;
    public float bulletSpeed;
    public float attackSpeed;

    public Transform player;

    public int playerAtkDmg = 1;

    private float time;

    public int patterIndex;
    public int curPatterCount;
    public int[] maxPatterCount;

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
            bullet.GetComponent<Crash>().atkDmg = playerAtkDmg;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shootDirection.normalized * bulletSpeed;

            Destroy(bullet, 2f);
        }

        if (transform.tag == "Monster")
        {
            time = 0;

            Vector3 dir = (player.position - bulletPos.transform.position).normalized;
            GameObject bullet = Instantiate(preFabBullet, bulletPos.transform.position, Quaternion.FromToRotation(Vector3.up, dir));

            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

            Destroy(bullet, 4f);

        }
    }

    private void OnEnable()
    {
        if (transform.tag == "Boss")
        {
            time = 0;
            Vector3 dir = (player.position - bulletPos.transform.position).normalized;
            GameObject bullet = Instantiate(preFabBullet, bulletPos.transform.position, Quaternion.FromToRotation(Vector3.up, dir));

            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

            Destroy(bullet, 4f);
            Invoke("Stop", 1.5f);
        }
    }

    void Stop()
    {
        if (!gameObject.activeSelf) return;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Invoke("Think", 1.5f);
    }

    void Think()
    {
        patterIndex = patterIndex == 2 ? 0 : patterIndex + 1;
        curPatterCount = 0;

        switch (patterIndex)
        {
            case 0:
                FourDirections();
                break;
            case 1:
                FireShotSecond();
                break;

            case 2:
                FireAround();
                break;

        }
    }

    void FourDirections()
    {
        GameObject bullet = Instantiate(preFabBullet, transform.position, Quaternion.identity);
        GameObject bullet2 = Instantiate(preFabBullet, transform.position, Quaternion.identity);
        GameObject bullet3 = Instantiate(preFabBullet, transform.position, Quaternion.identity);
        GameObject bullet4 = Instantiate(preFabBullet, transform.position, Quaternion.identity);

        Rigidbody2D rid = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rid2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rid3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rid4 = bullet4.GetComponent<Rigidbody2D>();

        rid.AddForce(Vector2.down * bulletSpeed, ForceMode2D.Impulse);
        rid2.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        rid3.AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);
        rid4.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);

        curPatterCount++;

        if (curPatterCount < maxPatterCount[patterIndex])
            Invoke("FireFoward", 2);
        else
            Invoke("Think", 1.5f);
    }

    void FireShotSecond()
    {
        GameObject bullet = Instantiate(preFabBullet, transform.position, Quaternion.identity);

        Rigidbody2D rid = bullet.GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * curPatterCount / maxPatterCount[patterIndex]), -1);

        rid.AddForce(dir.normalized * bulletSpeed, ForceMode2D.Impulse);

        curPatterCount++;

        if (curPatterCount < maxPatterCount[patterIndex])
        {
            Invoke("FireShotSecond", 0.15f);
        }
    }

    void FireAround()
    {
        int roundNuA = 50;
        int roundNuB = 40;
        int roundNuC = curPatterCount % 2 == 0 ? roundNuA : roundNuB;

        for(int index = 0; index < roundNuC;  index++)
        {
            GameObject bullet = Instantiate(preFabBullet, transform.position, Quaternion.identity);

            Rigidbody2D rid = bullet.GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / roundNuC), Mathf.Sin(Mathf.PI * 2 * index / roundNuC));

            rid.AddForce(dir.normalized * bulletSpeed, ForceMode2D.Impulse);
            Vector3 vec = Vector3.forward * 360 * index / roundNuC + Vector3.forward * 90;
            bullet.transform.Rotate(vec);
        }

        curPatterCount++;

        if (curPatterCount < maxPatterCount[patterIndex])
            Invoke("FireAround", 2);
        else
            Invoke("Think", 1.5f);
    }
}
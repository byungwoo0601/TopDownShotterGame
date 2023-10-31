using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Monster")
        {
            collision.gameObject.GetComponent<Traking>().hp--;

            if (collision.gameObject.GetComponent<Traking>().hp <= 0)
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }

        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().hp--;

            if (collision.gameObject.GetComponent<PlayerController>().hp <= 0)
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }


    }
}

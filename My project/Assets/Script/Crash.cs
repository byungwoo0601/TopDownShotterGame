using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    public int atkDmg;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Monster1" || collision.transform.tag == "Monster2" || collision.transform.tag == "Boss")
        {
            collision.gameObject.GetComponent<Traking>().hp =
                collision.gameObject.GetComponent<Traking>().hp - atkDmg;

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

                SceneManager.LoadScene("GameStart");
            }

            Destroy(gameObject);
        }


    }
}

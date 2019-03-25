using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Debug.Log("HIT!");
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public float bulletDamage;

    public EnemyController eC;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            eC.enemyHealth = eC.enemyHealth - bulletDamage;
            Debug.Log("HIT!");
        }
        Destroy(this.gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

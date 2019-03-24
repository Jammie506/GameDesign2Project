using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControllerReplace : MonoBehaviour
{
    public float speed;
    public Transform player;

    public int eHP;
    public int maxeHP;
    public Slider eHPSlider;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        eHPSlider.maxValue = maxeHP;
        eHP = maxeHP;
        eHPSlider.value = eHP;
    }

    void FixedUpdate()
    {
        //eHPSlider.value = eHP;

        Vector2 direction = player.position - transform.position;
        transform.Translate(direction * speed * Time.deltaTime);

        if (eHP <= 0)
        {
            Destroy(gameObject);

        }
    }

}
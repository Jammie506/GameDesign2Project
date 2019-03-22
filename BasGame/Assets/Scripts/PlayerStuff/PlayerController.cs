using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 direction;
    private float dir;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    public float rotSpeed = 5f;

    void Start()
    {
        
    }
    
    void Update()
    {
        GetInput();
        Move();

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        /*var mousePos = Input.mousePosition;
        mousePos.z = 10; // select distance = 10 units from the camera

        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);*/
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetInput()
    {
        direction = Vector2.zero;   

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            dir = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            dir = 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            dir = 3;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            dir = 4;
        }
    }
}

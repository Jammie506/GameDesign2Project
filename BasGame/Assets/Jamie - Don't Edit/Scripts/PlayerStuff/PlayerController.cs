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

    private float rotSpeed = 5f;

    Animator myAnim;
    public Transform animatorTransform;
    int NumberOfPunches;
    bool canPunch;
    bool _Ready;

    public Health h;


    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();

        NumberOfPunches = 0;
        canPunch = true;
        _Ready = false;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Combo();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            h.enemyHit();
        }
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
            //animatorTransform.localScale = new Vector3(-1, animatorTransform.localScale.y, animatorTransform.localScale.z);
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
            //animatorTransform.localScale = new Vector3(1, animatorTransform.localScale.y, animatorTransform.localScale.z);
        }
    }

    void Combo()
    {
        if (canPunch && !myAnim.GetCurrentAnimatorStateInfo(0).IsName("P3"))
        {
            NumberOfPunches++;
        }

        if (NumberOfPunches == 1)
        {
            myAnim.SetInteger("Clicks", 1);
        }
    }

    public void ComboCheck()
    {
        canPunch = false;

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("P1") && NumberOfPunches == 1)
        {
            myAnim.SetInteger("Clicks", 0);
            canPunch = true;
            NumberOfPunches = 0;
        }

        else if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("P1") && NumberOfPunches >= 2)
        {
            myAnim.SetInteger("Clicks", 2);
            canPunch = true;
        }

        else if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("P2") && NumberOfPunches == 2)
        {
            myAnim.SetInteger("Clicks", 0);
            canPunch = true;
            NumberOfPunches = 0;
        }

        else if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("P2") && NumberOfPunches >= 3)
        {
            myAnim.SetInteger("Clicks", 3);
            canPunch = true;
        }

        else if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("P3") && NumberOfPunches == 3)
        {
            myAnim.SetInteger("Clicks", 0);
            canPunch = true;
            NumberOfPunches = 0;
        }

        else
        {
            myAnim.SetInteger("Clicks", 0);
            canPunch = true;
            NumberOfPunches = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D _col)
    {
        Debug.Log("a");
        if (_Ready == true && _col.gameObject.tag == "Enemy")
        {
            //_Enemy.eHP -= 1;
            _col.gameObject.GetComponent<EnemyController>().enemyHealth -= 1;
            _Ready = false;
        }

        else if (_Ready == false)
        {
            return;
        }
    }

    public void EnemyDamage()
    {
        _Ready = true;
    }


    /*CODE GRAVEYARD (just in case)
      
        var mousePos = Input.mousePosition;
        mousePos.z = 10; // select distance = 10 units from the camera

        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

        enemyController _Enemy = _col.gameObject.GetComponent<enemyController>();

        if (_Enemy == null && !_Ready)
        {
            return;
        }
        
        else if (_Ready && NumberOfPunches == 0)
         {
             _Ready = false;
         }
     
     */
}

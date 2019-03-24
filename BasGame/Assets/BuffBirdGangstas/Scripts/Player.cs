using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]private float speed;
    Animator myAnim;
    public float maxSpeed;
    public float accelerationSpeed;
    Rigidbody2D myRb; 
    float currentSpeed;
    public Transform animatorTransform;
    private Vector2 direction;
    public float dir;
    int NumberOfPunches;
    bool canPunch;
    public GameObject poopUp, poopDown, poopRight, poopLeft;
    Vector2 bulletPos;
    public GameObject bullet;
    Vector2 myPos;
    bool _Ready;

    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        myRb = GetComponent<Rigidbody2D>();

        NumberOfPunches = 0;
        canPunch = true;
        _Ready = false;
    }

    public void ReloadScene()
    {
        Scene _CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_CurrentScene.name);
    }

    void Update()
    {
        /*currentSpeed = myRb.velocity.x;

        float move = Input.GetAxis("Horizontal");
        float upMove = Input.GetAxis("Vertical");


        if (move > 0)
        {
            animatorTransform.localScale = new Vector3(1, animatorTransform.localScale.y, animatorTransform.localScale.z);
        }
        else if (move < 0)
        {
            animatorTransform.localScale = new Vector3(-1, animatorTransform.localScale.y, animatorTransform.localScale.z);

        }

        if (Mathf.Abs(currentSpeed) < maxSpeed)
        {
            myRb.AddForce(new Vector2(move * accelerationSpeed, 0));

        }

        if (Mathf.Abs(currentSpeed) < maxSpeed)
        {
            myRb.AddForce(new Vector2(0, upMove * accelerationSpeed));
        }

        //myAnim.SetFloat("speed", (Mathf.Abs(currentSpeed + move)));
        */
        GetInput();
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Combo();
        }
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            dir = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            dir = 2;
            animatorTransform.localScale = new Vector3(-1, animatorTransform.localScale.y, animatorTransform.localScale.z);
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
            animatorTransform.localScale = new Vector3(1, animatorTransform.localScale.y, animatorTransform.localScale.z);
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

    void Fire()
    {
        bulletPos = transform.position;

        if (dir == 1)
        {
            Instantiate(poopUp, bulletPos, Quaternion.identity);
        }
        else if (dir == 2)
        {
            Instantiate(poopLeft, bulletPos, Quaternion.identity);
        }
        else if (dir == 3)
        {
            Instantiate(poopDown, bulletPos, Quaternion.identity);
        }
        else if (dir == 4)
        {
            Instantiate(poopRight, bulletPos, Quaternion.identity);
        }


        /*myPos = transform.position;
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = target - myPos;
        direction.Normalize();
        GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
        GetComponent<Rigidbody2D>().velocity = direction * speed;*/

    }

    private void OnTriggerStay(Collider _col)
    {
        /*enemyController _Enemy = _col.gameObject.GetComponent<enemyController>();

        if (_Enemy == null && !_Ready)
        {
            return;
        }*/
        Debug.Log("a");
        if (_Ready == true && _col.gameObject.tag == "Enemy")
        {
            //_Enemy.eHP -= 1;
           // _col.gameObject.GetComponent<enemyController>().eHP -= 1;
            _Ready = false;
        }

        else if (_Ready == false)
        {
            return;
        }

        /* else if (_Ready && NumberOfPunches == 0)
         {
             _Ready = false;
         }*/

    }

    public void EnemyDamage()
    {
        _Ready = true;
    }
}

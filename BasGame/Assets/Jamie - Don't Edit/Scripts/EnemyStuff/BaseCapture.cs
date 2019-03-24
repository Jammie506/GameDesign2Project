using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCapture : MonoBehaviour
{
    //time needed to stay in area to win Capture the Flag
    public float captureTime;
    
    //counter for in the Flag Area
    float inZone = 0.0f;

    bool enemies;

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            enemies = true;
        }
        else
        {
            enemies = false;
        }

        if (inZone > captureTime && enemies == false)
        {
            SceneManager.LoadScene("BaseCaptured");
        }

        //Debug.Log(inZone);
        //Debug.Log(enemies);
        Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inZone = inZone + Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || enemies == true)
        {
            inZone = 0.0f;
        }
    }
}

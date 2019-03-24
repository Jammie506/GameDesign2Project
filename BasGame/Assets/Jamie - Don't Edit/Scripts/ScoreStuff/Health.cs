using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int hV;
    Text health;
    public GameOver gO;

    void Start()
    {
        health = GetComponent<Text>();
    }

    void Update()
    {
        health.text = "Health - " + hV;

        if(Input.GetKeyDown(KeyCode.E))
        {
            hV--;
        }
        if(hV == 0)
        {
            gO.Dead();
        }
    }

    public void enemyHit()
    {
        hV--;
    }
}

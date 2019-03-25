using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerController pC;
    Text health;
    public GameOver gO;

    void Start()
    {
        health = GetComponent<Text>();
    }

    void Update()
    {
        health.text = "Health - " + pC.hV;

        if(Input.GetKeyDown(KeyCode.E))
        {
            pC.hV--;
        }
        if(pC.hV == 0)
        {
            gO.Dead();
        }
    }

    public void enemyHit()
    {
        pC.hV--;
    }
}

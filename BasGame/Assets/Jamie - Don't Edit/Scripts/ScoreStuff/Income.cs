using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Income : MonoBehaviour
{
    public int income;
    public ScoreScript sC;

    void Start()
    {
        InvokeRepeating("IncomeMath", 0, 1f);
    }
    
    void IncomeMath()
    {
        sC.sV += income;
    }
}

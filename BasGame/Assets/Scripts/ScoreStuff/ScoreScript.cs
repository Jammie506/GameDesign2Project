using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int sV = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }
    
    void Update()
    {
        score.text = "Cash : " + sV;
    }
}

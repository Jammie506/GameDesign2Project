using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeTell : MonoBehaviour
{
    public Income iC;
    Text Income;

    void Start()
    {
        Income = GetComponent<Text>();
    }
    
    void Update()
    {
        Income.text = "+ " + iC.income + "/s";
    }
}

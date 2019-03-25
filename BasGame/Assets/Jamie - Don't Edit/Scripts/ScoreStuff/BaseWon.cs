using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseWon : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("GameOver");
    }
}

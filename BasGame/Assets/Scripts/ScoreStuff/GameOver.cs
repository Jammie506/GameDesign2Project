using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Dead()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Moving " + collision.name);
            collision.transform.position = new Vector2(54, 0);
        }

            SceneManager.LoadScene("MainScene");
    }
}
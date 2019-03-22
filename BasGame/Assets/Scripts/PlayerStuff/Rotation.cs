using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotSpeed = 5f;

    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10; // select distance = 10 units from the camera

        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);
    }
}

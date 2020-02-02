using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject target;
    float radius = 8f, angleX = 0f, angleY = -45f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            radius -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 100f;
            angleX -= Input.GetAxis("Mouse X") * Time.deltaTime * 5f;
            angleY -= Input.GetAxis("Mouse Y") * Time.deltaTime * 5f;
        }

        float x = radius * Mathf.Cos(angleX) * Mathf.Sin(angleY);
        float z = radius * Mathf.Sin(angleX) * Mathf.Sin(angleY);
        float y = radius * Mathf.Cos(angleY);
        transform.position = new Vector3(x + target.transform.position.x,
                                         y + target.transform.position.y,
                                         z + target.transform.position.z);
        transform.LookAt(target.transform.position);
    }
}
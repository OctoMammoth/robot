using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 rotation;
    private void Update()
    {
        transform.Rotate(rotation.x, rotation.y, rotation.z);
    }
}

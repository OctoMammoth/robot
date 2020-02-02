using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titri : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            Application.LoadLevel(2);
    }
}

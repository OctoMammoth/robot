using UnityEngine;

public class RigidbodyAwake : MonoBehaviour
{
    Rigidbody rgd;
    GameObject character;

    int x, y, z;
    private void Awake()
    {
        rgd = GetComponent<Rigidbody>();
        character = GameObject.Find("Controller");

        RandomForce();
        rgd.AddForce(x, y, z);
    }

    void RandomForce()
    {
        //x = Random.Range(100, 200);
        y = Random.Range(1000, 2350);
        z = Random.Range(1000, 2350);
    }
}

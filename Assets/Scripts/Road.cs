using UnityEngine;

public class Road : MonoBehaviour
{
    public float _roadSpeed;

    private void Update()
    {
        transform.position += new Vector3(0, 0, _roadSpeed * Time.deltaTime);
    }
}

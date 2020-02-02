using UnityEngine;

public class PhysicsSelectObjects : MonoBehaviour
{
    GameObject controller;

    Rigidbody rgd;
    public ParticleSystem splark;
    //public float distance;
    public Transform trans;

    public bool _Head, _LeftArm, _RightArm, _LeftLeg, _LeftLeg_2, _RightLeg, _RightLeg_2, _LeftFoot, _RightFoot;
    private void Awake()
    {
        rgd = GetComponent<Rigidbody>();
        controller = GameObject.Find("Controller");
    }

    private void OnMouseDown()
    {
        rgd.isKinematic = true;
        transform.position = trans.position;
        transform.eulerAngles = trans.eulerAngles;
        splark.Stop();

        if (_Head == true)
            controller.GetComponent<GameManager>()._Head = true;
        if (_LeftArm == true)
            controller.GetComponent<GameManager>()._LeftArm = true;
        if (_RightArm == true)
            controller.GetComponent<GameManager>()._RightArm = true;
        if (_LeftLeg == true)
        {
            controller.GetComponent<GameManager>()._LeftLeg = true;
            controller.GetComponent<GameManager>()._LeftLeg_2 = true;
        }
        if(_LeftLeg_2 == true)
        {
            controller.GetComponent<GameManager>()._LeftLeg = true;
            controller.GetComponent<GameManager>()._LeftLeg_2 = true;
            controller.GetComponent<GameManager>()._LeftFoot = true;
        }
        if (_RightLeg == true)
        {
            controller.GetComponent<GameManager>()._RightLeg = true;
            controller.GetComponent<GameManager>()._RightLeg_2 = true;
            controller.GetComponent<GameManager>()._RightFoot = true;
        }
        if (_RightLeg_2 == true)
        {
            controller.GetComponent<GameManager>()._RightLeg = true;
            controller.GetComponent<GameManager>()._RightLeg_2 = true;
        }
        if (_LeftFoot == true)
        {
            controller.GetComponent<GameManager>()._LeftLeg = true;
            controller.GetComponent<GameManager>()._LeftLeg_2 = true;
            controller.GetComponent<GameManager>()._LeftFoot = true;
        }
        if (_RightFoot == true)
        {
            controller.GetComponent<GameManager>()._RightLeg = true;
            controller.GetComponent<GameManager>()._RightLeg_2 = true;
            controller.GetComponent<GameManager>()._RightFoot = true;
        }
    }

    /*        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;*/
}

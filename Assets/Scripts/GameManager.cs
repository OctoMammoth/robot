using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject _road;
    [HideInInspector]
    public bool isBroken;

    public GameObject _camera;
    public GameObject RunningCharacter, BrokenCharacter;
    public GameObject body;
    public Transform bodyTransform;
    public Transform spawn;
    public GameObject prefab_body, prefab_body_with_head;

    public GameObject RepairButton;
    [HideInInspector]
    public bool isRepair;

    [HideInInspector]
    public GameObject Head, LeftArm, RightArm, LeftLeg, LeftLeg_2, RightLeg, RightLeg_2, LeftFoot, RightFoot;
    [HideInInspector]
    public GameObject Head_r, LeftArm_r, RightArm_r, LeftLeg_r, LeftLeg_2_r, RightLeg_r, RightLeg_2_r, LeftFoot_r, RightFoot_r;
    [HideInInspector]
    public bool _Head, _LeftArm, _RightArm, _LeftLeg, _LeftLeg_2, _RightLeg, _RightLeg_2, _LeftFoot, _RightFoot;
    [HideInInspector]
    public bool newStart;
    int x, y, z;
    [HideInInspector]
    public bool refresh;
    public bool isGameOver;
    private void Awake()
    {
        RepairButton.SetActive(false);
        _road = GameObject.Find("Road");
        isBroken = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(0);

        if (isBroken)
        {
            _road.GetComponent<Road>()._roadSpeed = 0;
            _camera.GetComponent<Animator>().SetBool("broken", true);
            RunningCharacter.SetActive(false);
            BrokenCharacter.SetActive(true);
            RepairButton.SetActive(true);
            GetComponent<Control>().enabled = false;
        }
        else
        {
            _road.GetComponent<Road>()._roadSpeed = -10;
            _camera.GetComponent<Animator>().SetBool("broken", false);
            RunningCharacter.SetActive(true);
            BrokenCharacter.SetActive(false);
            RepairButton.SetActive(false);
            _camera.GetComponent<Animator>().enabled = true;
            _camera.GetComponent<ThirdPersonCamera>().enabled = false;
            GetComponent<Control>().enabled = true;
        }
        if (isRepair)
        {
            RepairButton.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            TimerEndFunction();
        }

        if (refresh)
        {
            RandomForce();
            //body.GetComponent<Rigidbody>().AddForce(x, y, z);
            Head_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            LeftArm_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            RightArm_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            LeftLeg_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            LeftLeg_2_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            RightLeg_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            RightLeg_2_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            LeftFoot_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            RightFoot_r.GetComponent<Rigidbody>().AddForce(x, y, z);
            refresh = false;
        }

        if (isGameOver)
        {
            _camera.GetComponent<Animator>().SetBool("broken", false);
            _camera.GetComponent<Animator>().enabled = true;
            _camera.GetComponent<ThirdPersonCamera>().enabled = false;
        }
    }

    public void TimerEndFunction()
    {
        RepairTimeIsEnd();
        isBroken = false;
        isRepair = false;
        body.GetComponent<Rigidbody>().isKinematic = false;
        Head_r.GetComponent<Rigidbody>().isKinematic = false;
        LeftArm_r.GetComponent<Rigidbody>().isKinematic = false;
        RightArm_r.GetComponent<Rigidbody>().isKinematic = false;
        LeftLeg_r.GetComponent<Rigidbody>().isKinematic = false;
        LeftLeg_2_r.GetComponent<Rigidbody>().isKinematic = false;
        RightLeg_r.GetComponent<Rigidbody>().isKinematic = false;
        RightLeg_2_r.GetComponent<Rigidbody>().isKinematic = false;
        LeftFoot_r.GetComponent<Rigidbody>().isKinematic = false;
        RightFoot_r.GetComponent<Rigidbody>().isKinematic = false;
        _Head = false;
        _LeftArm = false;
        _RightArm = false;
        _LeftLeg = false;
        _LeftLeg_2 = false;
        _RightLeg = false;
        _RightLeg_2 = false;
        _RightFoot = false;
        _LeftFoot = false;

        if (_Head == true && _LeftArm == false && _RightArm == false && _LeftLeg == false && _LeftLeg_2 == false && _RightLeg == false && _RightLeg_2 == false && _LeftFoot == false && _RightFoot == false)
        {
            //isGameOver = true;
        }
        if (_Head == false && _LeftArm == false && _RightArm == false && _LeftLeg == false && _LeftLeg_2 == false && _RightLeg == false && _RightLeg_2 == false && _LeftFoot == false && _RightFoot == false)
        {
            //isGameOver = true;
        }
    }

    void RandomForce()
    {
        //x = Random.Range(100, 200);
        y = Random.Range(1000, 2300);
        z = Random.Range(1000, 2300);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LetObject")
        {
            isBroken = true;
            Destroy(other.gameObject);
            Debug.Log("is broken...");
            newStart = true;
            refresh = true;
        }
    }

    public void StartRepair()
    {
        _camera.GetComponent<Animator>().enabled = false;
        _camera.GetComponent<ThirdPersonCamera>().enabled = true;
        body.GetComponent<Rigidbody>().isKinematic = true;
        body.transform.position = bodyTransform.position;
        body.transform.eulerAngles = bodyTransform.eulerAngles;
        isRepair = true;
    }

    void RepairTimeIsEnd()
    {
        RepairModule(_Head, Head);
        RepairModule(_LeftArm, LeftArm);
        RepairModule(_RightArm, RightArm);
        RepairModule(_LeftLeg, LeftLeg);
        RepairModule(_LeftLeg_2, LeftLeg_2);
        RepairModule(_RightLeg, RightLeg);
        RepairModule(_RightLeg_2, RightLeg_2);
        RepairModule(_LeftFoot, LeftFoot);
        RepairModule(_RightFoot, RightFoot);
        RepairModule(_LeftLeg, LeftFoot);
        RepairModule(_LeftLeg_2, LeftFoot);
        RepairModule(_RightLeg, RightFoot);
        RepairModule(_RightLeg_2, RightFoot);
        RepairModule(_Head, Head_r);
        RepairModule(_LeftArm, LeftArm_r);
        RepairModule(_RightArm, RightArm_r);
        RepairModule(_LeftLeg, LeftLeg_r);
        RepairModule(_LeftLeg_2, LeftLeg_2_r);
        RepairModule(_RightLeg, RightLeg_r);
        RepairModule(_RightLeg_2, RightLeg_2_r);
        RepairModule(_LeftFoot, LeftFoot_r);
        RepairModule(_RightFoot, RightFoot_r);
    }

    void RepairModule(bool boolean, GameObject objects)
    {
        if (boolean)
            objects.SetActive(true);
        else
            objects.SetActive(false);
    }

    /*_Head = false;
                _LeftArm = false;
                _RightArm = false;
                _LeftLeg = false;
                _LeftLeg_2 = false;
                _RightLeg = false;
                _RightLeg_2 = false;
                _RightFoot = false;
                _LeftFoot = false;
                newStart = false;*/
}

using UnityEngine;

public class Control : MonoBehaviour
{
    Animator anim;

    bool isLeft, isRight, isForward;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        isForward = true;
        isLeft = false;
        isRight = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            LeftMove();
        if (Input.GetKeyDown(KeyCode.D))
            RightMove();
    }

    public void LeftMove()
    {
        if(isRight == false)
        {
            anim.SetBool("left", true);
            anim.SetBool("forward", false);
            anim.SetBool("right", false);
            isForward = false;
            isLeft = true;
            isRight = false;
        }
        else
        {
            anim.SetBool("left", false);
            anim.SetBool("forward", true);
            anim.SetBool("right", false);
            isForward = true;
            isLeft = false;
            isRight = false;
        }
    }

    public void RightMove()
    {
        if(isLeft == false)
        {
            anim.SetBool("left", false);
            anim.SetBool("forward", false);
            anim.SetBool("right", true);
            isForward = false;
            isLeft = false;
            isRight = true;
        }
        else
        {
            anim.SetBool("left", false);
            anim.SetBool("forward", true);
            anim.SetBool("right", false);
            isForward = true;
            isLeft = false;
            isRight = false;
        }
    }
}

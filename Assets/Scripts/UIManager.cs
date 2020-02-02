using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject controller;

    float repairTimer;
    public float metrsFloat;

    public Text metrs, timer;

    public GameObject MainUI, RepairUI, FallUI, GameOver;

    bool oneMore;

    private void Awake()
    {
        repairTimer = 7f;
        controller = GameObject.Find("Controller");
        MainUI.SetActive(true);
        RepairUI.SetActive(false);
        FallUI.SetActive(false);
    }

    private void Update()
    {
        if (controller.GetComponent<GameManager>().isBroken == false)
        {
            MetrsChecker();
        }
        if (controller.GetComponent<GameManager>().isBroken)
        {
            MainUI.SetActive(false);
            RepairUI.SetActive(false);
            FallUI.SetActive(true);
            GameOver.SetActive(false);
        }
        else
        {
            RepairUI.SetActive(false);
        }
        if (controller.GetComponent<GameManager>().isRepair)
        {
            MainUI.SetActive(false);
            RepairUI.SetActive(true);
            FallUI.SetActive(false);
            GameOver.SetActive(false);
            Timer();
        }
        if (controller.GetComponent<GameManager>().isGameOver)
        {
            MainUI.SetActive(false);
            RepairUI.SetActive(false);
            FallUI.SetActive(false);
            GameOver.SetActive(true);
        }
        if (repairTimer <= 0)
        {
            if (oneMore)
            {
                controller.GetComponent<GameManager>().TimerEndFunction();
                oneMore = false;
                repairTimer = 7f;
            }
            oneMore = true;
        }
    }
    void Timer()
    {
        repairTimer -= Time.deltaTime * 2f;
        int repairInt = Mathf.RoundToInt(repairTimer);
        timer.text = repairInt.ToString() + " c";
    }

    void MetrsChecker()
    {
        metrsFloat -= Time.deltaTime * 10;

        int metrsInt = Mathf.RoundToInt(metrsFloat);
        metrs.text = metrsInt.ToString() + " m";
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
}

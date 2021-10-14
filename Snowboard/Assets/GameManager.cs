using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject tapToStart;
    public bool tap = false;

    public int coinCount = 0;

    public Text coinText;
    public Text winCoinText;
    public Text addCoinText;
    public Text standingsText;
    public Text standingsTextFinal;

    public GameObject winPanel;
    public GameObject startPanel;

    public static GameManager instance;

    public GameObject vcam2;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Standings.instance.order == 5 || Standings.instance.order == 4)
            standingsText.text = Standings.instance.order.ToString() + "th";
        if (Standings.instance.order == 3)
            standingsText.text = Standings.instance.order.ToString() + "rd";
        if (Standings.instance.order == 2)
            standingsText.text = Standings.instance.order.ToString() + "nd";
        if (Standings.instance.order == 1)
            standingsText.text = Standings.instance.order.ToString() + "st";

        if (Standings.instance.order == 5 || Standings.instance.order == 4)
            standingsTextFinal.text = Standings.instance.order.ToString() + "th";
        if (Standings.instance.order == 3)
            standingsTextFinal.text = Standings.instance.order.ToString() + "rd";
        if (Standings.instance.order == 2)
            standingsTextFinal.text = Standings.instance.order.ToString() + "nd";
        if (Standings.instance.order == 1)
            standingsTextFinal.text = Standings.instance.order.ToString() + "st";


        coinText.text = coinCount.ToString();
        winCoinText.text = coinCount.ToString();
        addCoinText.text = "+ " + coinCount.ToString();

        if (Input.GetMouseButton(0))
        {
            tap = true;
        }

        if (tap)
        {
            tapToStart.SetActive(false);
        }
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(0.5f);

        Player.instance.gameObject.transform.DORotate(new Vector3(0, 90, 0), 1).SetEase(Ease.Linear);
        //JoystickPlayerExample.instance.rightSpeed = 100;
        vcam2.GetComponent<CinemachineVirtualCamera>().Priority = 11;

        Player.instance.GetComponent<JoystickPlayerExample>().enabled = false;
        //Rival.instance.forwardSpeed = 0;
        winPanel.SetActive(true);
        startPanel.SetActive(false);
    }
}

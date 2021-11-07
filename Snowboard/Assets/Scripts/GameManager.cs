using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Single Scene Data")]
    
    public Level[] levels;
    public GameStatus status = GameStatus.empty;
    public int whichLevel = 0;

    public GameObject gameArea;

    public GameObject tapToStart;
    public bool tap = false;

    public int levelForText = 1;
    public int coinCount = 0;

    [Header("Texts")]

    public Text levelText;
    public Text coinText;
    //public Text winCoinText;
    //public Text addCoinText;
    public Text standingsText;
    //public Text standingsTextFinal;

    public GameObject coinEffect;

    [Header("Panels")]

    public GameObject winPanel;
    public GameObject failPanel;
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
        coinText.text = coinCount.ToString();

        //winCoinText.text = coinCount.ToString();
        //addCoinText.text = "+ " + coinCount.ToString();

        if (Input.GetMouseButton(0))
        {
            tap = true;
        }

        if (tap)
        {
            tapToStart.SetActive(false);
        }



        switch (status)
        {
            case GameStatus.empty:
                //bir prefabý var olan objeleri sahneye ekleyeceðim

                levelForText = PlayerPrefs.GetInt("level");
                whichLevel = PlayerPrefs.GetInt("whichLevel");
                coinCount = PlayerPrefs.GetInt("coinCount");

                levelText.text = (levelForText + 1).ToString();

                if (PlayerPrefs.GetInt("randomLevel") > 0)
                {
                    whichLevel = Random.Range(0, levels.Length);
                }

                gameArea = Instantiate(levels[whichLevel].LevelObj, new Vector3(0, -42, 483), Quaternion.Euler(0, -90, 0)); //alan info
                //Player = Instantiate(Levels[whichlevel].Player , new Vector3(0,0,0) , Quaternion.identity); //player info

                status = GameStatus.initalize;

                break;
            case GameStatus.initalize:
                //find iþlemleri

                break;
            case GameStatus.start:                
                break;
            case GameStatus.stay:
                break;
            case GameStatus.restart:
                break;
            case GameStatus.next:
                break;
        }

        Debug.Log(PlayerPrefs.GetInt("whichLevel") + " prefs");
        Debug.Log(whichLevel);


        if (Standings.instance.order == 8 || Standings.instance.order == 7 || Standings.instance.order == 6 || Standings.instance.order == 5 || Standings.instance.order == 4)
            standingsText.text = Standings.instance.order.ToString() + "th";
        if (Standings.instance.order == 3)
            standingsText.text = Standings.instance.order.ToString() + "rd";
        if (Standings.instance.order == 2)
            standingsText.text = Standings.instance.order.ToString() + "nd";
        if (Standings.instance.order == 1)
            standingsText.text = Standings.instance.order.ToString() + "st";


       
    }

    public void CoinEffect(GameObject gameObject)
    {
        GameObject coinEffectIns = Instantiate(coinEffect, gameObject.transform.position, coinEffect.transform.rotation);
        Destroy(coinEffectIns, 1f);
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(0.5f);

        Player.instance.gameObject.transform.DORotate(new Vector3(0, 90, 0), 1).SetEase(Ease.Linear);
        //JoystickPlayerExample.instance.rightSpeed = 100;
        vcam2.GetComponent<CinemachineVirtualCamera>().Priority = 11;

        vcam2.transform.GetChild(2).gameObject.SetActive(true);

        Player.instance.GetComponent<JoystickPlayerExample>().enabled = false;
        //Rival.instance.forwardSpeed = 0;
        winPanel.SetActive(true);
        startPanel.SetActive(false);

        yield return new WaitForSeconds(1);

        Player.instance.GetComponent<Animator>().SetBool("Flip", true);

        yield return new WaitForSeconds(0.1f);

        Player.instance.GetComponent<Animator>().SetBool("Flip", false);

        Player.instance.GetComponent<Animator>().SetBool("First", true);
    }

    public IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.5f);

        failPanel.SetActive(true);
        Player.instance.GetComponent<JoystickPlayerExample>().enabled = false;
    }

    public void Next()
    {
        whichLevel++;
        levelForText++;

        PlayerPrefs.SetInt("level", levelForText);
        PlayerPrefs.SetInt("whichLevel", whichLevel);
        PlayerPrefs.SetInt("coinCount", coinCount);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        status = GameStatus.empty;

        if (whichLevel >= levels.Length)
        {
            whichLevel--;
            PlayerPrefs.SetInt("randomLevel", 1);
        }
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

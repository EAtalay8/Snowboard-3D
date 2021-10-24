using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject speedText;
    public static Player instance;

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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedTrigger"))
        {
            //JoystickPlayerExample.instance.forwardSpeed = 75;
            StartCoroutine(RotateDelay());
        }

        if (other.gameObject.CompareTag("ExitTrigger"))
        {
            //JoystickPlayerExample.instance.forwardSpeed = 75;
            StartCoroutine(ExitDelay());
        }

        /*if (other.gameObject.CompareTag("Slope"))
        {
            JoystickPlayerExample.instance.forwardSpeed = ;
        }*/

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            GameManager.instance.coinCount++;
        }

        if (other.gameObject.CompareTag("EndPoint"))
        {
            StartCoroutine(GameManager.instance.Win());
        }

        if (other.gameObject.CompareTag("Boost"))
        {
            GetComponent<JoystickPlayerExample>().forwardSpeed += 30;
            //StartCoroutine(SpeedDelay());
            StartCoroutine(SpeedText());
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<JoystickPlayerExample>().forwardSpeed = 0;
            GetComponent<Animator>().SetBool("Falling", true);

            StartCoroutine(FallinDelay());
            //StartCoroutine(SpeedDelay());
        }

        if (other.gameObject.CompareTag("FinishTrap"))
        {
            transform.GetChild(8).gameObject.SetActive(false);
            StartCoroutine(Flip());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rival"))
        {
            if (GetComponent<JoystickPlayerExample>().forwardSpeed > 50)
                GetComponent<JoystickPlayerExample>().forwardSpeed -= 20;

            
        }

        if (collision.gameObject.CompareTag("EndPlane"))
        {
            //GetComponent<JoystickPlayerExample>().forwardSpeed = 0;
            //StartCoroutine(GameManager.instance.Win());

            StartCoroutine(DecreaseSpeed());
            transform.GetChild(8).gameObject.SetActive(true);
        }
    }

    public IEnumerator RotateDelay()
    {
        transform.GetChild(8).gameObject.SetActive(false);
        GetComponent<Animator>().SetBool("Flip", true);

        yield return new WaitForSeconds(0.1f);

        GetComponent<Animator>().SetBool("Flip", false);

        yield return new WaitForSeconds(130f / GetComponent<JoystickPlayerExample>().forwardSpeed);

        gameObject.transform.DORotate(new Vector3(25, 0, 0), 1);

        yield return new WaitForSeconds(255 / GetComponent<JoystickPlayerExample>().forwardSpeed);

        transform.GetChild(8).gameObject.SetActive(true);
    }

    public IEnumerator ExitDelay()
    {
        transform.GetChild(8).gameObject.SetActive(false);

        yield return new WaitForSeconds(195f / GetComponent<JoystickPlayerExample>().forwardSpeed);

        gameObject.transform.DORotate(new Vector3(0, 0, 0), 1);

        transform.GetChild(8).gameObject.SetActive(true);
    }

    public IEnumerator SpeedDelay()
    {
        yield return new WaitForSeconds(2);

        GetComponent<JoystickPlayerExample>().forwardSpeed = 100;
    }

    public IEnumerator FallinDelay()
    {
        yield return new WaitForSeconds(1);

        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);

        transform.DOMoveZ(transform.position.z - 50, 1);

        GetComponent<Animator>().SetBool("Falling", false);

        yield return new WaitForSeconds(1.5f);

        GetComponent<JoystickPlayerExample>().forwardSpeed = 50;

    }

    public IEnumerator DecreaseSpeed()
    {
        if (!(GetComponent<JoystickPlayerExample>().forwardSpeed <= 0))
        {

            yield return new WaitForSeconds(1);

            GetComponent<JoystickPlayerExample>().forwardSpeed -= 20;

            StartCoroutine(DecreaseSpeed());
        }

        else
        {
            StartCoroutine(GameManager.instance.Win());
        }
    }

    public IEnumerator SpeedText()
    {
        speedText.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        speedText.SetActive(false);
    }

    public IEnumerator SnowBall()
    {
        GetComponent<Animator>().SetBool("Snowball", true);

        yield return new WaitForSeconds(0.1f);

        GetComponent<Animator>().SetBool("Snowball", false);

        yield return new WaitForSeconds(.5f);

        Time.timeScale = 1;
    }

    public IEnumerator Flip()
    {
        yield return new WaitForSeconds(0.5f);

        GetComponent<Animator>().SetBool("Flip", true);

        yield return new WaitForSeconds(0.1f);

        GetComponent<Animator>().SetBool("Flip", false);
    }
}
